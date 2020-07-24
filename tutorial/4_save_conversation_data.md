# 대화 내용 기억하기

이 문서에서는 Chat Bot이 사용자와의 대화 내용을 저장하고 이를 활용하는 방법을 다룹니다.



### 0. 구현 환경 준비

필요한 구현 환경은 다음과 같습니다.

- Visual Studio Community 2019 다운로드 및 설치 (https://visualstudio.microsoft.com/ko/)
- Bot Framework v4 SDK Templates  다운로드 및 설치 (https://aka.ms/bf-bc-vstemplate)
- Bot Framework Emulator 다운로드 및 설치 (https://github.com/microsoft/BotFramework-Emulator)

**[주의 사항]**

<u>Visual Studio Community 2019</u>: **알맞은 OS**의 Visual Studio Installer를 통해  Visual Studio Community 2019를 설치합니다. 여기서 **ASP.NET 및 웹 개발**과 **Azure 개발** 항목을 반드시 포함시켜 설치합니다.



### 1. 상태 저장

[Bot은 기본적으로 상태 비저장](https://docs.microsoft.com/ko-kr/azure/bot-service/bot-builder-howto-v4-state?view=azure-bot-service-4.0&tabs=csharp)입니다. 따라서 구현한 Bot Class의 멤버 변수가 사용자와의 대화를 통해 수정되더라도 다음 대화에서 초기화된 상태로 돌아옵니다. 그러나 Bot은 대화의 문맥에 따라 동작을 수행하기 위해 이전 메시지를 기억해야 할 수도 있습니다.

이 프로젝트가 목표하고 있는 숫자 야구 Chat Bot의 경우 **게임이 시작했는지**, **설정한 숫자는 무엇인지**, **게임이 끝났는지** 등을 파악할 필요가 있습니다. 일반적인 프로그램이라면 변수를 통해 이를 확인할 수 있지만 Bot은 상태를 저장하지 않기 때문에 불가능합니다.

이를 위해 Bot은 상태 관리 및 스토리지 개체를 사용하여 상태를 관리하고 유지합니다.



상태 관리의 첫 단계는 관리하려는 정보를 포함하는 Class를 정의하는 것입니다. 이 프로젝트에서는 숫자 야구 Chat Bot 개발에 맞추어 Class를 GameChecker라 이름 짓고 `GameChecker.cs`를 다음과 같이 작성했습니다.

```c#
public class GameChecker
{
	public bool IsInGame { get; set; } = false;

    public string ComputerNumber { get; set; } = "";
}
```

`IsInGame`은 게임이 시작되었는지 알리는 변수이며 사용자가 **게임 시작** 기능을 입력하거나 [이전에 구현된 버튼](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/3_suggestion.md)으로 접근하면  `true`로 값이 전환됩니다. `ComputerNumber`는 컴퓨터가 기억하고 사용자가 맞춰야할 숫자입니다.



다음으로 `ConversationState` 개체를 만드는 데 사용하는 `MemoryStorage`를 등록합니다. 이 대화 개체는 `Startup.cs`에서 이루어지며 이는 Bot 생성자에 주입됩니다.

**[주의사항]** [이 문서의 코드](https://github.com/BullsAndCowsBot/chatbot/tree/master/project/BullsAndCows_0.5)는 [이전 코드](https://github.com/BullsAndCowsBot/chatbot/tree/master/project/BullsAndCows_0.1)와 달리 프로젝트 생성 시에 Empty Bot을 만들어 수행되었습니다. 따라서 `EchoBot`이 `EmptyBot`으로 작성되어 있으니 착오 없으시길 바랍니다.

```C#
public void ConfigureServices(IServiceCollection services)
{
	services.AddControllers().AddNewtonsoftJson();

	// Create the Bot Framework Adapter with error handling enabled.
	services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

	var storage = new MemoryStorage();

	var conversationState = new ConversationState(storage);
	services.AddSingleton(conversationState);

	// Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
	services.AddTransient<IBot, EmptyBot>();
}
```



이제 `EmptyBot.cs`에서  멤버 변수와 Bot 생성자를 정의합니다.

```c#
private BotState _conversationState;

public EmptyBot(ConversationState conversationState)
{
	_conversationState = conversationState;
}
```



이제 이를 활용하기 위해 접근자인 `gameCheckerAccessors`를 만들고 이를 `gameData`를 통해 접근합니다.

```c#
protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
{
	var gameCheckerAccessors = _conversationState.CreateProperty<GameChecker>(nameof(GameChecker));
	var gameData = await gameCheckerAccessors.GetAsync(turnContext, () => new GameChecker());
    .
    .
    .
}
```

`gameData`는 `GameChecker` Class에 따라 다음과 같은 구조를 가지게 됩니다. 또 `gameData.IsInGame`, `gameData.ComputerNumber`와 같이 사용하여 상태를 저장하고 활용할 수 있습니다. 

```
gameData
├ IsInGame (bool)
└ ComputerNumber (string) 
```



정보가 대화 안에서 변한 경우 저장할 상태를 수정해야 하기 때문에 `EmptyBot.cs`에 아래와 같은 method를 추가합니다.

```c#
public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
{
	await base.OnTurnAsync(turnContext, cancellationToken);

	// Save any state changes that might have occurred during the turn.
	await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
}
```



위와 같이 `conversationState`를 통해 Bot의 대화 상태를 저장할 수 있습니다. 

이 문서에서 사용된 코드는 모두 [이 곳](https://github.com/BullsAndCowsBot/chatbot/tree/master/project/BullsAndCows_0.5)에 있습니다. 또 [이 곳](https://bullsandcowsbot.github.io/bullsandcows_v05.html)에서 구현된 Chat Bot을 테스트할 수 있습니다.

프로젝트의 가장 최신 코드는 [이 곳](https://github.com/BullsAndCowsBot/chatbot/tree/master/project/BullsAndCows_1)에 있습니다. 또 [이 곳](https://bullsandcowsbot.github.io/bullsandcows_v1.html)에서 이를 테스트할 수 있습니다.

------

이 프로젝트는 KCC2020에서 이루어진 **Microsoft와 함께하는 Chatbot 경진대회**에서 진행되었습니다.
