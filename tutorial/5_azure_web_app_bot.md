# Azure web app bot 배포하기

이 문서에서는 Azure을 사용하여 **web app bot**을 만들어 배포하는 것에 대해 다룹니다.

### 0. 'Azure' wep app bot 만들기

우선 Azure을 사용할 수 있는 계정을 준비해야 합니다.
Azure을 사용하기 위한 적당한 subscription이 없다면 평가판을 신청해서 사용할 수 있습니다.

계정이 준비됬다면 우선 리소스 그룹을 생성해야 합니다.
메뉴에서 리소스 그룹을 선택한 뒤, '추가'를 선택합니다. (리소스 그룹 -> 추가)

<img src="..\imgs\make_resourceGroup.png"/>

추가를 선택한 뒤에 리소스 그룹명을 입력하고 영역을 '한국 중부'로 설정해줍니다.

<img src="..\imgs\add_resourceGroup.png"/>

입력한 뒤, 만들기 버튼을 누르게 되면 리소스 그룹이 생성됩니다.
생성된 후에 해당 리소스 그룹에 접속하여 '추가 버튼'을 선택합니다.

<img src="..\imgs\add_resourceGroup(2).png"/>

이후에 나타나는 화면에서 Wep App Bot을 검색, 클릭하여 만들기를 클릭합니다.
그러고나면 세부 정보를 입력할 수 있는 화면이 나타납니다.
먼저 봇의 이름(봇 핸들)을 중복되지 않도록 입력합니다.
다음으로 구독과 리소스 그룹 정보를 설정하고 위치를 Korea Central로 설정한 뒤,
가격 책정 계층은 'F0'으로 설정합니다.
**F0은 무료로 제공되고 있기 때문에 개발, 학습 용도로 적절하게 사용할 수 있습니다**
그 후에 앱의 이름을 입력합니다.

<img src="..\imgs\input_info.png"/>

봇 템플릿은 기본 설정으로 놔두시면 되고, Application Insight는 일단 해제를 선택해주시면 됩니다.
그 다음으로 '앱 서비스 계획/유지' 설정을 위해 버튼을 클릭합니다.
나타나는 화면에서 기존에 사용하고 있는 앱 서비스가 있으면 선택해주시면 되고, 새로 생성하시려면
'새로 생성' 버튼을 클릭하시고, 앱 서비스 계획의 이름을 입력한 뒤 Korea Central로 위치를 바꿔주시면 됩니다.

<img src="..\imgs\appService.png"/>

최종적으로 만들기를 눌러주시면, 약간의 소요시간 후에 서비스가 잘 생성된 것을 보실 수 있습니다.
다시 리소스 그룹을 확인해보시면 '웹 앱 봇', 'App Service', 'App Service 계획' 3가지가 생성된 것을
확인하실 수 있습니다.
여기서 웹 앳 봇을 선택하시고 '구성'버튼을 누릅니다.

<img src="..\imgs\checkBotMade.png"/>

여기서 MicrosoftAppId와 MicrosoftAppPassword 두 항목을 눌러서 확인한 뒤 따로 저장해 둡니다.

<img src="..\imgs\IDPW.png"/>

이렇게 하면 Azure 페이지에서 wepp app bot을 만드는 과정은 완료됩니다.

### 1. Visual Studio에서 배포하기

visual studio를 통해 프로젝트를 킨 뒤, 우측 솔루션 탐색기에서 'appsettings.json'을 클릭한 뒤,
방금 확인했던 MicrosoftAppId와 MicrosoftAppPassword를 알맞게 입력해 줍니다.

<img src="..\imgs\appsettings(visual studio).png"/>

이 후, 솔루션 탐색기에서 프로젝트 이름 위에서 마우스 우클릭을 해서 '게시' 항목을 클릭합니다.

<img src="..\imgs\post(vs).png"/>

그럼 다음과 같은 화면이 나오게 되고, 여기서 Azure을 선택한 뒤, 본인 개발 환경에 맞춰 선택을 해주시면 됩니다.

<img src="..\imgs\post(vs-azure).png"/>

최종적으로 자신이 설정한 웹 앳 봇을 선택하면 프로젝트가 빌드되고 배포되는 것을 확인하실 수 있습니다.
(이 과정에서 Azure 계정 로그인을 요청할 수도 있습니다)

<img src="..\imgs\finalSelect(vs).png"/>

배포 이후에 Azure 사이트로 돌아가 웹 앳 봇의 '웹 채팅에서 테스트'를 선택하여 배포가 잘 되었는지
확인하면 웹 앱 봇 제작 및 배포 과정이 완료되게 됩니다.

------

이 프로젝트는 KCC2020에서 이루어진 **Microsoft와 함께하는 Chatbot 경진대회**에서 진행되었습니다.
