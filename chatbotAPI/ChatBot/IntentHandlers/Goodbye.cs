using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public class Goodbye : IIntentHandler
    {
        private static Random rnd = new Random();

        public async Task<string> HandleIntent(RecognizerResult prediction)
        {
            var list = new List<string>
            {
                "Adeus :)",
                "Até uma próxima!",
                "Fico à sua espera numa próxima oportunidade!",
                "Espero tê-lo ajudado. Até uma próxima!",
                "Adeus! Até à próxima!"
            };

            var i = rnd.Next(list.Count);

            return list[i];
        }
    }
}
