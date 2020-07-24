# 이미지 첨부하여 전달하기

이 문서에서는 Bot의 응답 메시지로 이미지를 첨부하여 전달하는 방법을 다룹니다.



### 0. 구현 환경 준비

필요한 구현 환경은 다음과 같습니다.

- Visual Studio Community 2019 다운로드 및 설치 (https://visualstudio.microsoft.com/ko/)
- Bot Framework v4 SDK Templates  다운로드 및 설치 (https://aka.ms/bf-bc-vstemplate)
- Bot Framework Emulator 다운로드 및 설치 (https://github.com/microsoft/BotFramework-Emulator)

**[주의 사항]**

<u>Visual Studio Community 2019</u>: **알맞은 OS**의 Visual Studio Installer를 통해  Visual Studio Community 2019를 설치합니다. 여기서 **ASP.NET 및 웹 개발**과 **Azure 개발** 항목을 반드시 포함시켜 설치합니다.



### 1. 이미지 첨부하여 메시지 보내기

우리는 앞서 [Echo Bot](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/0_echobot.md)을 만들고 Echo Bot의 [응답 메시지를 수정](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/1_modify_message.md)했습니다. 이 문서에서는 문자열에 이미지를 함께 첨부하여 메시지를 보내는 방법에 대해 다룰 것입니다. 이미지를 첨부하는 방법은 <u>프로젝트에 포함되어 있는 이미지를 읽어서 첨부하는 방법</u>과 <u>인터넷에 올라와 있는 이미지의 주소를 통해 첨부하는 방법</u>이 있습니다. 이 문서에서는 이미지의 URL을 통해 이를 첨부하는 방법을 다루겠습니다.

이미지를 첨부하기 위해서는 별도의 Activity 객체가 필요합니다. 따라서 `EchoBot.cs` 아래와 같은 method를 추가합니다.

``` c#
private static Activity ProcessInput(ITurnContext turnContext)
{
	var activity = turnContext.Activity;
	var reply = activity.CreateReply();

	return reply;
}
```

다음으로 첨부할 파일을 인터넷 URL에서 가져오는 method를 추가합니다. `ContentUrl`은 이미지가 존재하는 주소를 의미합니다. 이 문서에서는 해당 프로젝트에서 사용된 로고 이미지를 예시로 사용했습니다.

```c#
private static Attachment GetInternetAttaachment()
{
	return new Attachment
	{
		Name = @"Resources\architecture-resize.png",
		ContentType = "image/png",
		ContentUrl = "https://github.com/BullsAndCowsBot/chatbot/blob/master/imgs/logo.png?raw=true",
	};
}
```

 

이제 구현한 method를 활용합니다. 예시로 기존 `OnMembersAddedAsync`를 수정하여 사용자가 새로 들어왔을 때 이미지를 첨부하여 메시지를 보내도록 해봅시다.

```c#
protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
{
	var reply = ProcessInput(turnContext);

	reply.Text = "안녕하세요 베이스 볼 챗 입니다.";
	reply.Attachments = new List<Attachment>() { GetInternetAttaachment() };

	foreach (var member in membersAdded)
	{
		if (member.Id != turnContext.Activity.Recipient.Id)
		{
			await turnContext.SendActivityAsync(reply, cancellationToken);
		}
	}
}
```

[메시지를 수정 했던 Echo Bot](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/1_modify_message.md)의 `OnMembersAddedAsync` 안에서 새로운 Activity 객체를 만들고 적절한 Text와 이미지를 첨부하여 Bot의 메시지를 만들었습니다. 이를 테스트하면 사용자가 처음 채널에 들어왔을 때 다음 메시지를 받습니다.

<img src="..\imgs\image_attach.png"/>

단순히 문자열을 메시지로 활용하는 것이 아니라 이미지를 함께 참부하여 전달하는 방법을 다루었습니다. 예시로 제시한 사용자의 첫 접속 뿐만 아니라, `OnMessageActivityAsync`에서도 이를 활용할 수 있습니다.

------

이 프로젝트는 KCC2020에서 이루어진 **Microsoft와 함께하는 Chatbot 경진대회**에서 진행되었습니다.



