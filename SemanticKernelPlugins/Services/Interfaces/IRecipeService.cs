using SemanticKernelPlugins.Models;

namespace SemanticKernelPlugins.Services.Interfaces;

public interface IRecipeService
{
    Task<Recipe> GetRecipeByDifficultyAsync(string difficulty);
}
