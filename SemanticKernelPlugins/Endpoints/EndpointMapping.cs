using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OllamaApiFacade.Extensions;

namespace SemanticKernelPlugins.Endpoints;

public static class EndpointMapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapOpenAiEndpoints();
    }

    private static void MapOpenAiEndpoints(this WebApplication app)
    {
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
    }
}
