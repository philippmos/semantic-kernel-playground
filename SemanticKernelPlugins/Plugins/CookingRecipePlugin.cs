using System.ComponentModel;
using Microsoft.SemanticKernel;
using SemanticKernelPlugins.Services.Interfaces;

namespace SemanticKernelPlugins.Plugins;

public class CookingRecipePlugin(IRecipeService recipeService)
{
    [KernelFunction]
    [Description("Returns a cooking recipe that matches the specified difficulty level. Difficulty can be Easy, Medium, Hard, or Extreme.")]
    public string GetCookingRecipeByGivenDifficulty(
        [Description("The difficulty level of the recipe to retrieve. Valid values: Easy, Medium, Hard, Extreme.")] string difficulty)
    {
        var recipe = recipeService.GetRecipeByDifficultyAsync(difficulty).Result;

        if (recipe is null)
        {
            return $"We could not find a cooking recipe that matches your difficulty {difficulty}.";
        }

        return recipe.ToString();
    }
}
