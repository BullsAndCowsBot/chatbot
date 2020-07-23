# Echo Bot 만들기

이 문서에서는 단순히 사용자의 입력을 포함하여 반환하는 **Echo Bot**을 구현합니다.



### 0. 준비

필요한 환경은 다음과 같습니다.

- Visual Studio Community 2019 다운로드 및 설치 (https://visualstudio.microsoft.com/ko/)
- Bot Framework v4 SDK Templates  다운로드 및 설치 (https://aka.ms/bf-bc-vstemplate)
- Bot Framework Emulator 다운로드 및 설치 (https://github.com/microsoft/BotFramework-Emulator)

**[주의 사항]**

<u>Visual Studio Community 2019</u>: **알맞은 OS**의 Visual Studio Installer를 통해  Visual Studio Community 2019를 설치합니다. 여기서 **ASP.NET 및 웹 개발**과 **Azure 개발** 항목을 반드시 포함시켜 설치합니다.

![주의사항](..\imgs\notice.png)



### 1. Echo Bot

Echo Bot은 단순히 사용자의 입력을 포함하여 반환합니다.

![만들기](..\imgs\make_echobot.png)

Visual Studio를 실행하고 새 프로젝트 만들기를 선택하면 위와 같은 화면이 나타납니다. **Echo Bot**을 검색하여 프로젝트를 **다음**을 누르고 알맞은 이름과 위치를 설정하고 프로젝트를 생성합니다.

코드를 이해하기 앞서 Echo Bot을 실행해봅시다. Visual Studio 상단의 **IIS Express**를 누릅니다.

![test](..\imgs\test.png) 

이를 실행하면 http://localhost:3978/ 를 통해 Chat Bot이 실행되고 있음을 알리는 브라우저가 나타납니다.



![테스트 실행](..\imgs\bot_emulator.png)

이제 **Open Bot**을 눌러 Bot 동작하고 있는 주소인  http://localhost:3978/api/messages 를 Bot URL의 공란에 작성하고 연결합니다. 필요 요소들이 제대로 설치되어 있다면 사용자의 말을 따라하는 Echo Bot을 만날 수 있습니다.

Bot 프로젝트를 생성하고 만들고 Emulator를 활용하여 만들어진 Chat Bot을 테스트했습니다. 앞으로 만들어질 Chat Bot의 로컬 테스트는 위와 같은 방법으로 이루어질 수 있습니다.

------

이 프로젝트는 KCC2020에서 이루어진 **'Microsoft와 함께하는 Chatbot 경진대회'**에서 진행되었습니다.



