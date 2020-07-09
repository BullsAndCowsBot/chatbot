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

			if (userText == "���� �˷��ּ���")
			{
				reply.Text = "�츮�� ê���� ���� ���� �߱� ������ ����� �ֽ��ϴ�.";
			}
			else if (userText == "���� �̸���?")
			{
				reply.Text = "���� �߱� ����. ���̽� �� ���Դϴ�~";
			}
			else if (userText == "���� ����")
			{
				reply.Text = "�غ� ���Դϴ�.";
			}
			else
			{
				reply.Text = $"'{userText}' : ������ ���� ����������, ������ �� �ȶ������ڽ��ϴ�.";
				reply.SuggestedActions = new SuggestedActions()
				{
					Actions = new List<CardAction>()
					{
						new CardAction() { Title = "���� �˷��ּ���", Type = ActionTypes.ImBack, Value = "���� �˷��ּ���" },
						new CardAction() { Title = "���� �̸���?", Type = ActionTypes.ImBack, Value = "���� �̸���?" },
						new CardAction() { Title = "���� ����", Type = ActionTypes.ImBack, Value = "���� ����" },
					},
				};
			}

			await turnContext.SendActivityAsync(reply, cancellationToken);
		}

		protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
		{
			var reply = ProcessInput(turnContext);

			reply.Text = "�ȳ��ϼ��� ���̽� �� ê �Դϴ�.";
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
