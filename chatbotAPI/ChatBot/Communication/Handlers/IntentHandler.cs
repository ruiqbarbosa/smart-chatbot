using ChatBot.Communication.Clients;
using Microsoft.Bot.Builder;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Communication.Handlers
{
    public static class IntentHandler
    {
        public static async Task<RecognizerResult> GetRecognizerResult(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var luisClient = LuisClient.GetClient(turnContext, cancellationToken);
            if (luisClient == null)
                return null;

            return await luisClient.RecognizeAsync(turnContext, cancellationToken);
        }

    }
}
