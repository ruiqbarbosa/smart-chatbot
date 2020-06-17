// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.5.0

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ChatBot.Communication.Handlers;
using ChatBot.Infrastructure.Crosscutting;
using ChatBot.IntentHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace ChatBot.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string responseMessage = "";

            var recognizerResult = await IntentHandler.GetRecognizerResult(turnContext, cancellationToken);

            if (recognizerResult != null)
            {

                var (intent, score) = recognizerResult.GetTopScoringIntent();

                IIntentHandler handler;
                switch (intent)
                {
                    case UserIntents.Greetings:
                        handler = new Greetings();
                        responseMessage = await handler.HandleIntent(recognizerResult).ConfigureAwait(false);
                        break;
                    case UserIntents.Goodbye:
                        handler = new Goodbye();
                        responseMessage = await handler.HandleIntent(recognizerResult).ConfigureAwait(false); ;
                        break;
                    case UserIntents.Movements_List:
                        handler = new MovementsList();
                        responseMessage = await handler.HandleIntent(recognizerResult).ConfigureAwait(false); ;
                        break;
                    case UserIntents.Movement_Common_Mistakes:
                        handler = new MovementCommonMistakes();
                        responseMessage = await handler.HandleIntent(recognizerResult).ConfigureAwait(false); ;
                        break;
                    case UserIntents.Movement_Steps:
                        handler = new MovementSteps();
                        responseMessage = await handler.HandleIntent(recognizerResult).ConfigureAwait(false); ;
                        break;
                    case UserIntents.Movement_Tips:
                        handler = new MovementTips();
                        responseMessage = await handler.HandleIntent(recognizerResult).ConfigureAwait(false); ;
                        break;
                    default:
                        responseMessage = "Não consegui perceber o que pretende. Por favor explique-se de outra forma.";
                        break;
                };
            }
            else
            {
                responseMessage = "Occoreu um erro. Por favor, tente mais tarde.";
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(responseMessage), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            //foreach (var member in membersAdded)
            //{
            //    if (member.Id != turnContext.Activity.Recipient.Id)
            //    {
            //        await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and welcome!"), cancellationToken);
            //    }
            //}
        }
    }
}
