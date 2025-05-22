using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OllamaApiFacade.Extensions;
using SemanticKernelPlugins.Plugins;

var builder = WebApplication
                    .CreateBuilder(args)
                    .ConfigureAsLocalOllamaApi();

builder.Services
    .AddKernel()
    .AddLmStudio()
    .Plugins.AddFromType<TimeInformationPlugin>();

var app = builder.Build();

app.MapPostApiChat(async (chatRequest, chatCompletionService, httpContext, kernel) =>
{
    var chatHistory = chatRequest.ToChatHistory();

    var promptExecutionSettings = new OpenAIPromptExecutionSettings
    {
        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
    };

    await chatCompletionService
        .GetStreamingChatMessageContentsAsync(chatHistory, promptExecutionSettings, kernel)
        .StreamToResponseAsync(httpContext.Response);
});

app.Run();
