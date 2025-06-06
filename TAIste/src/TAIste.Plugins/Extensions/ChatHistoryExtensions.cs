using Microsoft.SemanticKernel.ChatCompletion;
using TAIste.Plugins.Helpers;

namespace TAIste.Plugins.Extensions;

public static class ChatHistoryExtensions
{
    public static async Task<ChatHistory> AddInstructionPrompts(this ChatHistory chatHistory)
    {
        var systemPrompt = await InstructionPromptReader.ReadSystemPromptAsync();

        if (!string.IsNullOrEmpty(systemPrompt))
        {
            chatHistory.AddSystemMessage(systemPrompt);
        }

        var assistantPrompt = await InstructionPromptReader.ReadAssistantPromptAsync();

        if (!string.IsNullOrEmpty(assistantPrompt))
        {
            chatHistory.AddAssistantMessage(assistantPrompt);
        }


        return chatHistory;
    }
}
