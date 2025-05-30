using System.ComponentModel;
using Microsoft.SemanticKernel;
using TAIste.Plugins.Services.Interfaces;

namespace TAIste.Plugins.Plugins;

public class CookingRecipePlugin(IRecipeService recipeService)
{
    [KernelFunction]
    [Description("Returns a cooking recipe that matches the specified difficulty level. Difficulty can be Easy, Medium, Hard, or Extreme.")]
    public string GetCookingRecipeByGivenDifficulty(
        [Description("The difficulty level of the recipe to retrieve. Valid values: Easy, Medium, Hard, Extreme.")] string difficulty)
    {
        var recipes = recipeService.GetAllRecipes().Result;

        if (recipes is null || !recipes.Any())
        {
            return $"We could not find a cooking recipe that matches your difficulty {difficulty}.";
        }

        return recipes.FirstOrDefault()?.ToString() ?? "Could not find any cooking recipe";
    }
}
