# 도전 숫자 야구

Bulls And Cows Chat Bot: 숫자 야구 챗봇 프로젝트

<img src=".\imgs\logo.png"/>

## 0. 구현 과정

이 프로젝트는 Chat Bot 개발에 관심을 가진 사람들이 관련 정보를 얻을 수 있도록 모든 과정을 기록했습니다.

[첫번째, Echo Bot 만들기](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/0_echobot.md)

[두번째, Message 수정하기](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/1_modify_message.md)

[세번째, 이미지 첨부하여 전달하기](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/2_attachment_image.md)

[네번째, 버튼으로 기능 유도하기](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/3_suggestion.md)

[다섯번째, 대화 내용 기억하기](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/4_save_conversation_data.md)

[여섯번째, web app bot 만들고 배포하기](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/5_azure_web_app_bot.md)

[일곱번째, Addressable한 web chatbot 만들기(github 웹 호스팅)](https://github.com/BullsAndCowsBot/chatbot/blob/master/tutorial/6_github_page.md)

## 1. 기본 게임 규칙

숫자야구는 감춰진 3개의 숫자를 맞추는 게임입니다.
양 플레이어가 한번씩 돌아가면서 질문과 대답을 하게 되며, 게임의 규칙은 다음과 같습니다.

1. 3자리 숫자와 위치가 정확하게 맞아야 합니다
2. 숫자는 0~9까지 수로 구성되어 있으며, 중복될 수 없습니다.
3. 숫자와 위치가 모두 맞으면 스트라이크(S), 숫자만 맞으면 볼(B) 입니다.
4. 숫자가 하나도 일치하지 않는 경우 아웃(O)입니다.

ex) 감춰진 숫자가 369인 경우
-396 : 1S 2B
-862 : 1S 2O

## 2. 챗봇 사용방법

접근 방법: [도전 숫자 야구](https://bullsandcowsbot.github.io/index.html)

플레이어는 bot과 1:1로 숫자야구 게임을 진행하며 챗봇의 숫자를 맞추면 승리합니다.

##### 1) 챗봇 시작

'도전 숫자 야구'는 사용자의 입력에 의해 인사말과 로고와 함께 시작합니다.
(미리 설정된 사항 외 입력 시에는 특정 멘트와 함께 선택할 수 있는 메뉴가 제공됩니다)

<img src=".\imgs\start_screen.PNG"/> (시작 화면)

게임 모드는 2가지가 있습니다.
'일반 게임 모드' : 제한된 횟수 내에서 숫자를 맞추어야 승리하는 모드
'무한 게임 모드' : 횟수 제한 없이 숫자를 맞출 수 있는 모드

##### 2) 게임 시작

'게임 시작'을 입력하면 멘트와 함께 게임이 시작됩니다.

<img src=".\imgs\start_normalMode.PNG"/>

<img src=".\imgs\start_infinityMode.PNG"/>

봇의 숫자를 맞추기 위해, 세 개의 숫자를 한번에 입력하여 메세지를 보냅니다.

ex) 369, 345, 789, 123

이 때, 허용되지 않은 숫자를 입력시 '조건에 어긋나는 입력입니다'가 출력되며 다시 입력해야 합니다.
입력 시 지켜야 할 조건 사항은 다음과 같습니다.

1. 3자리 (ex. **1234, 12**와 같은 경우 X)
2. 음이 아닌 정수 (ex. **aaa, b23**와 같은 경우 X)
3. 중복 불가 (ex. **111, 993**와 같은 경우 X)

숫자를 맞추려는 사용자에 입력에 대해 봇은 [#S #B #O]와 같은 형식으로 결과를 알려줍니다.

ex) [1S 0B 2O]

<img src=".\imgs\ask_example.PNG"/>

<img src=".\imgs\notDigit.PNG"/>

<img src=".\imgs\repetition.PNG"/>

<img src=".\imgs\OverNumber.PNG"/>

최종적으로 3S, 즉 세 자리 숫자와 각각의 위치까지 정확히 맞추게 되면 게임이 종료되게 됩니다.
(일반 모드에서는 정해진 횟수 내에 클리어해야 합니다!)

<img src=".\imgs\gameEnd.PNG"/>
