# Intelligent Fitness ChatBot 

This project provides an entire example about how to integrate a ChatBot in a mobile application using an API and a language understanding service.
The [Azure Bot](https://azure.microsoft.com/pt-pt/services/bot-service/) and the [Language Understanding](https://www.luis.ai/) services from Microsoft were used to develop this project. Besides that, a react native mobile app and a ASP.NET Web API were also implemented, allowing the interaction between the user and the bot, and the access of the database, respectability.

Please read the next sections in order to have a good understanding of the architecture and the workflow of this project.

## Table of contents

1. [Showcase](#showcase)
1. [Workflow](#workflow)
1. [API](#api)
1. [Language Understanding: LUIS](#language-understanding-luis)
1. [Azure ChatBot](#azure-chatbot)
1. [Mobile Application](#mobile-application)
1. [Setup](#setup)

## Showcase
![ChatBot 1](https://i.imgur.com/IDeTYal.gif)  ![ChatBot 2](https://i.imgur.com/KrbNtLV.gif)
## Workflow
In the next picture the interaction of all components of the current project will be represented through a sequence diagram.

![Sequence diagram](https://i.ibb.co/30MrJ8G/Sequence-Diagram-PVA.jpg)

Briefly, when a user sends a message through the chat of the mobile app, a ChatBotAPI (Azure Bot Service) is called. Then, the LUISAPI (Language Understanding) is invoked. The main goal of this service is to find the intention behind the user message using a model prediction based in machine learning. After the return of the most scored intent from LUISAPI, the ChatBotAPI analyzes what is the behavior of the respective intent, and, in most cases, the FitnessAPI is called to return the data from the database. In the end, the message is returned to the mobile application allowing the user to see the ChatBot response.

## API
In order to allow obtaining data from the database, an ASP.NET API was created. It was used some design patterns as MVC, DTO and Repository. 
It is not presented the whole API code, although you can see an entire use case - retrieve information about fitness movements/exercises.

## Language Understanding: LUIS
The LuisAPI is used to interpret the user's messages, adding intelligence to the ChatBot. Thus, a welcome message can be written in different ways (e.g. hello, good morning, hi, hello, good night, among others), which the ChatBot will understand and respond with meaning.

In this repository you can only see how the LUIS API is invoked (presented in ChatBotAPI), all the rest - creation of language understaing model, entities, etc - were done through the [LUIS Portal](https://www.luis.ai/).
## Azure ChatBot
The bot response handler is presented in this component. Firstly, the LUIS API is invoked in order to get the most scored intent. Then, using the Strategy Pattern, the respective intent behavior will be executed, as mentioned above.

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
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
                    ...
                };
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(responseMessage), cancellationToken);
        }

## Mobile Application
In order to allow the interaction between the user and the bot, a react mobile application was created. To provide such interaction, a chat and a direct line communication were used. 
## Setup
There are services that need to be configured. You can follow the next steps to setup a similar project to this or use the available code to create your own project.

### Language Understanding - LUIS
To create an LUIS application you can follow the [Microsoft tutorial](https://docs.microsoft.com/pt-pt/azure/cognitive-services/luis/luis-get-started-create-app) or if you want to know more details about this service you can watch [Codepunk's youtube video](https://www.youtube.com/watch?v=9zp06zhYkO0).

After LUIS app creation, you have to do the following steps:

 1. Create an intent (e.g Greetings);
 2. Create utterances for that intent (e.g hello, good morning, hi, etc);
 3. Create/Train model
 4. Test
 5. Deploy
### Mobile Application and Azure ChatBot
The integration between the mobile app and the azure chat bot is presented in this repository, but if you want to create your own applications or know specific details, you can check [Adrian Carolli article](https://blog.expo.io/so-you-want-to-build-a-chat-app-with-react-native-expo-and-microsofts-bot-framework-4d2327f76ce3).