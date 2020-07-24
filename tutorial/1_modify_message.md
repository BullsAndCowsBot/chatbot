# Echo Bot Message 수정하기

이 문서에서는 사용자의 메시지에 대한 Echo Bot의 응답 메시지를  수정하는 방법을 나타냅니다.



### 0. 구현 환경 준비

필요한 구현 환경은 다음과 같습니다.

- Visual Studio Community 2019 다운로드 및 설치 (https://visualstudio.microsoft.com/ko/)
- Bot Framework v4 SDK Templates  다운로드 및 설치 (https://aka.ms/bf-bc-vstemplate)
- Bot Framework Emulator 다운로드 및 설치 (https://github.com/microsoft/BotFramework-Emulator)

**[주의 사항]**

<u>Visual Studio Community 2019</u>: **알맞은 OS**의 Visual Studio Installer를 통해  Visual Studio Community 2019를 설치합니다. 여기서 **ASP.NET 및 웹 개발**과 **Azure 개발** 항목을 반드시 포함시켜 설치합니다.



### 1. OnMessageActivityAsync, OnMembersAddedAsync

[이전 튜토리얼](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/0_echobot.md)에서 Echo Bot 프로젝트를 생성하고 이를 Emulator로 테스트했습니다.

Echo Bot에 접속하면 Bot의 첫 메시지는 **Hello and welcome**이며 사용자의 입력에 **Echo**를 붙여 메시지를 전달합니다.

<img src="..\imgs\welcome.png"/>

이번에는 `EchoBot.cs`의 구조를 이해하고 코드를 수정하는 것으로 Bot의 응답 메시지를 바꾸어 테스트 해보겠습니다.

Echo Bot 프로젝트의 Bots 폴더에는 `EchoBot.cs` 파일이 존재합니다. `EchoBot.cs`는 Class와 그 동작을 정의한 파일입니다. `EchoBot.cs`는 다음과 같은 구조로 되어있습니다.

```
EchoBot (Class)
├ OnMessageActivityAsync (Method)
└ OnMembersAddedAsync (Method)
```



`OnMessageActivityAsync`는 사용자의 입력에 따른 동작을 결정합니다. 코드에서 확인할 수 있는 것처럼 우리의 Echo Bot은 사용자의 입력을 그대로 사용하여 이를 메시지로 전달합니다.

```c#
protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
{
	var replyText = $"Echo: {turnContext.Activity.Text}";
	await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
}
```

코드에서도 확인할 수 있듯이 사용자의 입력에 대해 **Echo**를 붙여 이를 Bot의 메시지로 활용합니다. `var replyText = $"Echo: {turnContext.Activity.Text}";`는 `Echo:`라는 문자열과 사용자의 응답 문자열이 담긴 `turnContext.Activity.Text`를 합치고 응답 메시지에 사용되는 `replyText`에 저장합니다. 따라서 `replyText`에 할당되는 문자열을 수정하면 다른 문자열을 메시지로 활용하도록 만들 수 있습니다.



Chat Bot의 첫 메시지인 **Hello and welcome**은 `OnMembersAddedAsync`에 구현되어 있습니다. 테스트를 통해 알아볼 수 있듯이 `OnMembersAddedAsync`는 사용자가 처음 접근했을 때 동작합니다. 

```c#
protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
{
	var welcomeText = "Hello and welcome!";
	foreach (var member in membersAdded)
	{
		if (member.Id != turnContext.Activity.Recipient.Id)
		{
			await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
		}
	}
}
```

따라서 코드의 **Hello and welcome**을 다른 문자열로 수정하면 우리가 원하는 첫 메시지로 바꿀 수 있습니다.



이제  출력되길 원하는 문자열로 `OnMessageActivityAsync`와 `OnMembersAddedAsync`를 수정하고 Bot Framework Emulator에서 이를 테스트합니다. 필요한 요소들이 모두 갖추어져 있다면 새로운 Echo Bot은 정상적으로 동작할 것입니다.

------

이 프로젝트는 KCC2020에서 이루어진 **Microsoft와 함께하는 Chatbot 경진대회**에서 진행되었습니다.



