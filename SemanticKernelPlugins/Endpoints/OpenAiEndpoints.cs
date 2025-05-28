using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OllamaApiFacade.Extensions;
using SemanticKernelPlugins.Extensions;

namespace SemanticKernelPlugins.Endpoints;

public static class OpenAiEndpoints
{
    public static void MapOpenAiEndpoints(this WebApplication app)
    {
        app.MapPostApiChat(async (chatRequest, chatCompletionService, httpContext, kernel) =>
        {
            var chatHistory = await chatRequest
                                        .ToChatHistory()
                                        .AddInstructionPrompts();

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
