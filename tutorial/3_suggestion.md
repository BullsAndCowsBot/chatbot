# 버튼으로 입력하게 유도하기

이 문서에서는 사용자게에 버튼을 제안하는 것으로 올바른 입력을 유도하는 방법에 대해 알아봅니다.



### 0. 구현 환경 준비

필요한 구현 환경은 다음과 같습니다.

- Visual Studio Community 2019 다운로드 및 설치 (https://visualstudio.microsoft.com/ko/)
- Bot Framework v4 SDK Templates  다운로드 및 설치 (https://aka.ms/bf-bc-vstemplate)
- Bot Framework Emulator 다운로드 및 설치 (https://github.com/microsoft/BotFramework-Emulator)

**[주의 사항]**

<u>Visual Studio Community 2019</u>: **알맞은 OS**의 Visual Studio Installer를 통해  Visual Studio Community 2019를 설치합니다. 여기서 **ASP.NET 및 웹 개발**과 **Azure 개발** 항목을 반드시 포함시켜 설치합니다.



### 1. 버튼으로 입력 유도하기

앞서 Echo Bot의 [메시지를 수정](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/1_modify_message.md)하고 [이미지를 첨부](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/2_attachment_image.md)하는 방법을 배웠습니다. 일반적인 Chat Bot은 사용자의 입력을 바탕으로 정보를 제공하거나 기능을 수행합니다. 그렇다면 사용자가 기능에 없는 메시지를 입력하면 어떻게 될까요? 이러한 문제를 해결하거나 사용자에게 기능을 제시하기 위하여 `CardAction`을 통해 버튼을 구현합니다. 이를 활용하여 Chat Bot이 더 명확한 시나리오를 갖게 할 수 있습니다.

이 문서에서는 Echo Bot에서 마주 했었던 `OnMessageActivityAsync`를 수정하여 버튼을 구현해보겠습니다.

**[주의사항]** 아래의 코드를 그대로 활용하는 경우 [이미지를 첨부](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/2_attachment_image.md)할 때 구현했던 `ProcessInput` method가 필요합니다.

```c#
protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
{
	var userText = turnContext.Activity.Text;
	var reply = ProcessInput(turnContext);

	if (userText == "목적 알려주세요")
	{
		reply.Text = "우리는 챗봇을 상대로 숫자 야구 게임을 만들고 있습니다.";
	}
	else if (userText == "너의 이름은?")
	{
		reply.Text = "숫자 야구 게임. 베이스 볼 쳇입니다~";
	}
	else if (userText == "게임 시작")
	{
		reply.Text = "준비 중입니다.";
	}
	else // 사용자 메시지의 문자열을 이해할 수 없는 경우
	{
		reply.Text = $"'{userText}' : 아직은 많이 부족하지만, 앞으로 더 똑똑해지겠습니다.";
		reply.SuggestedActions = new SuggestedActions()
		{
			Actions = new List<CardAction>()
			{
				new CardAction() { Title = "목적 알려주세요", Type = ActionTypes.ImBack, Value = "목적 알려주세요" },
				new CardAction() { Title = "너의 이름은?", Type = ActionTypes.ImBack, Value = "너의 이름은?" },
				new CardAction() { Title = "게임 시작", Type = ActionTypes.ImBack, Value = "게임 시작" },
			},
		};
	}

	await turnContext.SendActivityAsync(reply, cancellationToken);
}
```

수정된 `OnMessageActivityAsync`는 사용자 메시지의 문자열에 대해 기능을 수행합니다. Chat Bot은 사용자의 메시지 문자열이 [**목적 알려주세요.**, **너의 이름은?**, **게임 시작**]에 대해서만 동작하며, 사용자의 문자열을 이해할 수 없는 `else`의 경우 이해할 수 없다는 문자열과 버튼을 담아 메시지를 보냅니다.

버튼이 존재하는 메시지를 만들기 위해서  `ProcessInput`를 통해 만들어진 `reply`의 `Text`를 수정합니다. `reply.SuggestedActions = new SuggestedActions(){...}`을 통해 제안하는 기능들을 `CardAction`으로 추가합니다.

위와 같이 `OnMessageActivityAsync`를 작성했을 때  [**목적 알려주세요.**, **너의 이름은?**, **게임 시작**] 외의 다른 메시지에 Chat Bot은 다음과 같이 동작합니다.

<img src="..\imgs\button_example.png"/>

이번에는 사용자가 Chat Bot의 시나리오를 벗어나지 않고 기능을 제안할 수 있는 버튼을 만드는 방법에 대해 알아보았습니다.

------

이 프로젝트는 KCC2020에서 이루어진 **Microsoft와 함께하는 Chatbot 경진대회**에서 진행되었습니다.



