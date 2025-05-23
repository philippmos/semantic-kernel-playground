using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OllamaApiFacade.Extensions;
using SemanticKernelPlugins.Plugins;

var builder = WebApplication
                    .CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.WebHost.UseUrls("");
builder.WebHost.UseKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(11434);
});

builder.Services
    .AddKernel()
    .AddLmStudio(endpoint: builder.Configuration["LMStudioUrl"] ?? throw new Exception("LMStudioUrl missing"))
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
