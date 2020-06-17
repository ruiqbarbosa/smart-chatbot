using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using System;
using System.Threading;

namespace ChatBot.Communication.Clients
{
    public static class LuisClient
    {
        public static LuisRecognizer GetClient(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            try
            {
                // Create the LUIS settings from configuration.
                var luisApplication = new LuisApplication(
                    "applicationId - should be accessed from configurations file",
                    "endpointKey - should be accessed from configurations file",
                    "endpoint"
                );

                return new LuisRecognizer(luisApplication);

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
