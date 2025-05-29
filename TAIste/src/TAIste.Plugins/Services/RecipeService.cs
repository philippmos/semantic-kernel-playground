using MongoDB.Driver;
using TAIste.Plugins.Models;
using TAIste.Plugins.Services.Interfaces;

namespace TAIste.Plugins.Services;

public class RecipeService : IRecipeService
{
    private readonly IMongoCollection<Recipe> _collection;

    public RecipeService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDb")
                ?? configuration["MongoDb"]
                ?? throw new Exception("MongoDb ConnectionString missing");

        _collection = new MongoClient(connectionString)
                                .GetDatabase("taiste")
                                .GetCollection<Recipe>("cooking_recipes");
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipes()
    {
        var recipes = await _collection.Find(_ => true).ToListAsync();
        return recipes;
    }
}
