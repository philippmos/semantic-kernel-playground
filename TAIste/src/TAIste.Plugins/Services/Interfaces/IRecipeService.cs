using TAIste.Plugins.Models;

namespace TAIste.Plugins.Services.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GetAllRecipes();
}
