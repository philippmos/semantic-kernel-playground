using TAIste.Plugins.Models;

namespace TAIste.Plugins.Services.Interfaces;

public interface IRecipeService
{
    Task<Recipe> GetRecipeByDifficultyAsync(string difficulty);
}
