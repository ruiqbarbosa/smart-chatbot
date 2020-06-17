using ChatBot.Communication.Handlers;
using ChatBot.Infrastructure.Extensions;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Bot.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public class MovementCommonMistakes : IIntentHandler
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

            if(entity == null)
                return "Precisa de indicar o exercício pretendido. Responda com 'exercícios' se pretender ver a lista.";

            var (statusCode, movementInfo) = await FitnessApiGateway.GetMovementInfo(entity.Text);

            if (statusCode == 200)
            {
                if (movementInfo.CommonMistakes.Count() == 0) {
                    return "Neste momento não existe informação sobre os erros mais comuns desse exercício.";
                }
                else {
                    string response = "Alguns erros comuns: \n\n- ";
                    string commonMistakes = string.Join("\n\n- ", movementInfo.CommonMistakes);

                    return response + commonMistakes;
                }

            } else if (statusCode == 404)
            {
                return "O exercício que indicou não existe. Responda com 'exercícios' se pretender ver a lista.";

            } else
            {
                return "Ocorreu um erro. Por favor tente mais tarde.";
            }
        }
    }
}
