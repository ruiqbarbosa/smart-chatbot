using ChatBot.Communication.Handlers;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public class MovementsList : IIntentHandler
    {
        public async Task<string> HandleIntent(RecognizerResult prediction)
        {
            List<string> movements = await FitnessApiGateway.GetMovementsNames();

            return string.Join("\n\n", movements);
        }
    }
}
