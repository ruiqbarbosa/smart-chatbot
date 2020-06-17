using ChatBot.Communication.Handlers;
using ChatBot.Infrastructure.Extensions;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public class MovementSteps : IIntentHandler
    {
        public async Task<string> HandleIntent(RecognizerResult prediction)
        {
            LuisEntity entity;
            try
            {
                entity = prediction.Entities.GetEntity("movementName");
            }
            catch (Exception e)
            {
                return "Ocorreu um erro. Por favor tente mais tarde.";
            }

            if (entity == null)
                return "Precisa de indicar o exercício pretendido. Responda com 'exercícios' se pretender ver a lista.";

            var (statusCode, movementInfo) = await FitnessApiGateway.GetMovementInfo(entity.Text);

            if (statusCode == 200)
            {
                if (movementInfo.Steps.Count() == 0)
                {
                    return "Neste momento não existem instruções para esse exercício.";
                }
                else
                {
                    string response = "Instruções do exercício: \n\n";
                    string steps = string.Join("\n\n ", movementInfo.Steps);

                    return response + steps;
                }

            }
            else if (statusCode == 404)
            {
                return "O exercício que indicou não existe. Responda com 'exercícios' se pretender ver a lista.";
            }
            else
            {
                return "Ocorreu um erro. Por favor tente mais tarde.";
            }
        }
    }
}
