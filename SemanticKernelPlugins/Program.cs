using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OllamaApiFacade.Extensions;
using SemanticKernelPlugins;
using SemanticKernelPlugins.Hosting;

var builder = ApiWebApplication
                    .CreateBuilder(args);

builder.Services.SetupKernel(builder.Configuration);

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
