using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public class Greetings : IIntentHandler
    {
        private static Random rnd = new Random();

        public async Task<string> HandleIntent(RecognizerResult prediction)
        {
            var list = new List<string>
            {
                "Olá, em que posso ajudar?",
                "Viva, estou aqui para o ajudar! De que necessita?",
                "Bom dia, em que lhe posso ser útil?",
                "Olá, em que o posso ajudar?",
                "Olá",
                "Viva! :)",
                "Bom dia!",
                "Bom dia! Eu sou o assistente pessoal. Em que o posso ajudar?"
            };

            var i = rnd.Next(list.Count);

            return list[i];
        }
    }
}
