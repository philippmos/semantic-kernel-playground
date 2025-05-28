using SemanticKernelPlugins.Models;
using SemanticKernelPlugins.Models.Enums;
using SemanticKernelPlugins.Services.Interfaces;

namespace SemanticKernelPlugins.Services;

public class RecipeService : IRecipeService
{
    public async Task<Recipe> GetRecipeByDifficultyAsync(string difficulty)
    {
        var difficultyEnum = Difficulty.Easy;

        _ = await Task.FromResult(Enum.TryParse(difficulty, out difficultyEnum));

        return new()
        {
            Id = new Guid(),
            Name = $"{difficulty}: Spanischer Erdbeereintopf mit Kohlrabi",
            Difficulty = difficultyEnum,
            Ingredients = ["Tomatoes", "Olive Oil", "Garlic", "Basil"]
        };
    }
}
