using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.IntentHandlers
{
    public interface IIntentHandler
    {
        Task<string> HandleIntent(RecognizerResult prediction);
    }
}
