using OllamaApiFacade.Extensions;

var builder = WebApplication
                    .CreateBuilder(args)
                    .ConfigureAsLocalOllamaApi();

builder.Services.AddKernel().AddLmStudio();

var app = builder.Build();

app.MapPostApiChat(async (chatRequest, chatCompletionService, httpContext, kernel) =>
{
    var chatHistory = chatRequest.ToChatHistory();

    await chatCompletionService
        .GetStreamingChatMessageContentsAsync(chatHistory)
        .StreamToResponseAsync(httpContext.Response);
});

app.Run();
