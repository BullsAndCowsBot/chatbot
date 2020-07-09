// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace BullsAndCows_0._1
{
	public class BACBot : ActivityHandler
	{
		private static Activity ProcessInput(ITurnContext turnContext)
		{
			var activity = turnContext.Activity;
			var reply = activity.CreateReply();

			return reply;
		}

		private static Attachment GetInternetAttaachment()
		{
			return new Attachment
			{
				Name = @"Resources\architecture-resize.png",
				ContentType = "image/png",
				ContentUrl = "https://github.com/JunYoung7/BullsAndCows-chatbot/blob/master/imgs/logo.png?raw=true",
			};
		}

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
			else
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
	}
}
