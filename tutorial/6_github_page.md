# Addressable한 Web chatbot 만들기(github 웹호스팅 이용)

이 문서에서는 만든 Azure 웨 앱 봇의 임베드 코드를 얻어 addressable한 URL에 연결된 Web chatbot을 만드는 것을 다루고 있습니다.

### 0. 봇 임베드 코드 얻기

Microsoft Azure 포털에서 자신이 만든 웹 앱 봇을 클릭합니다.
이 후, 왼쪽 메뉴에서 '채널'을 선택합니다.

<img src="..\imgs\chooseChanel.png"/>

나타나는 화면에서 '봇 임베드 코드 얻기'를 클릭합니다.

<img src="..\imgs\getCode.png"/>

'Web Chat 구성 페이지를 열려면 이곳을 클릭하세요.'를 클릭합니다.

<img src="..\imgs\botCodeMenu.png"/>

여기서 임베드 코드를 본인이 파일에 복사한 뒤, '내 비밀' 영역에 암호키를 입력합니다.

<img src="..\imgs\botCodePW.png"/>

암호키가 입력된 html 파일을 잘 저장합니다.

<img src="..\imgs\vsBotCode.png"/>

### 1. Github를 통해 Addressable한 URL 만들기(웹 호스팅)

1-1. 우선 github 계정으로 로그인한 후, repository를 생성합니다.
(github 계정이 없는 사람은 우선 github 계정을 만드 후 진행해주시면 됩니다)

우측 상단에 있는 + 버튼을 누른 뒤, 'New repository'를 클릭합니다.

<img src="..\imgs\github(make_repository).png"/>

repository 이름을 작성해주신 후 공개여부는 public을 선택하시고,
아래 초기화 하겠냐는 체크 박스를 클릭해주신 뒤, 'create repository'를 클릭해주시면 됩니다.

<img src="..\imgs\github(input_Info_Repository).png"/>

1-2. repository가 만들어지면 'ADD file' 버튼을 누르면 나오는 메뉴에서 'Upload files'을 선택합니다.

<img src="..\imgs\github(choose_upload_file).png"/>

이 후, choose your files를 선택하신 뒤에 아까 전에 저장한 봇 임베드 코드가 저장되어 있는 html 파일을 upload합니다.
(image 파일 등 호스팅할 관련 파일들을 upload한다고 생각하시면 됩니다)

<img src="..\imgs\github(uploadFiles).png"/>

잘 업로드가 되었다면, Commit changes 공간에서 내용을 입력하시고 'commit changes'를 누르시면 됩니다.
(간단하게 변경사항에 대해 기재할 수 있는 공간이라고 생각하시면 됩니다)

<img src="..\imgs\github(commit).png"/>

1-3. 이제 저장소에 파일들이 잘 업로드 되었다면, 상단에 'Settings' 탭으로 이동합니다.

<img src="..\imgs\github(choose_settings).png"/>

아래로 쭉 내리시다보면, 'GitHub Pages' 항목이 있는데 여기서 'None'을 'master branch'으로 바꿔줍니다.

<img src="..\imgs\github(choose_master).png"/>

새로고침된 페이지를 쭉 다시 내리시면,
"Your site is ready to be published at https://(깃허브 아이디).github.io/(현재 저장소 이름)/."
형식으로 깃허브 서버를 통해 만들어진 웹사이트 URL을 최종적으로 제공받으실 수 있습니다.

이제 주소창에 해당 url을 입력하신 뒤 마지막 '/'뒤에 자신이 웹 호스팅을 통해 열고자 하는 업로드한 html 파일명을 입력하시면
만들어진 web chatbot을 확인하실 수 있습니다.

<img src="..\imgs\github(final).png"/>

---

이 프로젝트는 KCC2020에서 이루어진 **Microsoft와 함께하는 Chatbot 경진대회**에서 진행되었습니다.
