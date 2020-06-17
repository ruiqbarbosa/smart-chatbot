using ChatBot.Communication.Handlers;
using ChatBot.Infrastructure.Extensions;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public class MovementTips : IIntentHandler
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
                if (movementInfo.Tips.Count() == 0)
                {
                    return "Neste momento não existem dicas para esse exercício.";
                }
                else
                {
                    string response = "Algumas dicas: \n\n- ";
                    string tips = string.Join("\n\n- ", movementInfo.Tips);

                    return response + tips;
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
