# BullsAndCows-chatbot
숫자야구 챗봇 프로젝트

<img src=".\imgs\logo.png"/>

## 1. 게임 규칙

숫자야구는 감춰진 3개의 숫자를 맞추는 게임입니다.
양 플레이어가 한번씩 돌아가면서 질문과 대답을 하게 되며,
게임의 규칙은 다음과 같습니다.

1) 3자리 숫자와 위치가 정확하게 맞아야 합니다
2) 숫자는 0~9까지 수로 구성되어 있으며, 중복될 수 없습니다.
3) 숫자와 위치가 모두 맞으면 스트라이크(S), 숫자만 맞으면 볼(B) 입니다.
4) 숫자가 하나도 일치하지 않는 경우 아웃(OUT)입니다.

ex) 감춰진 숫자가 369인 경우
-396 : 1S 2B
-862 : 1S

## 2. 챗봇 사용방법

플레이어는 bot과 1:1로 숫자야구 게임을 진행하게 되며, 먼저 3S를 달성하여
상대방의 숫자와 위치를 전부 맞추는 쪽이 승리합니다.

**상대방에게 숫자를 물어볼 때**

세 개의 숫자를 한번에 입력하여 메세지를 보냅니다.

ex) 369, 345, 789, 123

**상대방에 질문에 답변할 때**

상대방의 질문을 듣고 '#S #B'의 형태로 답변합니다.
숫자를 하나도 맞추지 못한 경우 OUT으로 표현합니다.

ex) 2S 1B, 1S 2B, 3S, OUT




