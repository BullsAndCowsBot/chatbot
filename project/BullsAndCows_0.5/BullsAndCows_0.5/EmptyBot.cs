// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace BullsAndCows_0._5
{
	public class EmptyBot : ActivityHandler
	{
		private BotState _conversationState;

		public EmptyBot(ConversationState conversationState)
		{
			_conversationState = conversationState;
		}

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
				ContentUrl = "https://github.com/BullsAndCowsBot/chatbot/blob/master/imgs/logo.png?raw=true",
			};
		}

		public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
		{
			await base.OnTurnAsync(turnContext, cancellationToken);

			// Save any state changes that might have occurred during the turn.
			await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
		}

		protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
		{
			var gameCheckerAccessors = _conversationState.CreateProperty<GameChecker>(nameof(GameChecker));
			var gameData = await gameCheckerAccessors.GetAsync(turnContext, () => new GameChecker());

			var userText = turnContext.Activity.Text;
			var reply = ProcessInput(turnContext);

			if (gameData.IsInGame)
			{
				Player Computer = new Player(gameData.ComputerNumber);

				if (Computer.CheckIntegrity(userText))
				{
					var result = Computer.CheckNumber(userText);

					if (result == "YOU WIN")
					{
						reply.Text = $"{result} ������ �����մϴ�. ({Computer.getNumber()})";
						gameData.IsInGame = false;
						gameData.ComputerNumber = "";
					}
					else { reply.Text = $"{result} ({Computer.getNumber()})"; }
				}
				else { reply.Text = "���ǿ� ��߳��� �Է��Դϴ�."; }
			}
			else
			{
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
					reply.Text = "������ �����մϴ�. 3�ڸ� ���ڸ� �Է����ּ���. (�ߺ� �Ұ�)";
					gameData.IsInGame = true;
					Player Computer = new Player();
					gameData.ComputerNumber = Computer.getNumber();
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
