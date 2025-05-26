namespace SemanticKernelPlugins.Helpers;

public static class InstructionPromptReader
{
    public static async Task<string> ReadSystemPromptAsync()
    {
        return await ReadAsync(GetPromptFilePath("SystemPrompt"));
    }

    public static async Task<string> ReadAssistantPromptAsync()
    {
        return await ReadAsync(GetPromptFilePath("AssistantPrompt"));
    }


    private static string GetPromptFilePath(string fileName)
    {
        return Path.Combine("Prompts", $"{fileName}.txt");
    }

    private static async Task<string> ReadAsync(string filePath)
    {
        try
        {
            return await File.ReadAllTextAsync(filePath);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}
