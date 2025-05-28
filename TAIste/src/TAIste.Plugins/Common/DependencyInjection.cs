using TAIste.Plugins.Services;
using TAIste.Plugins.Services.Interfaces;

namespace TAIste.Plugins.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IRecipeService, RecipeService>();

        return services;
    }
}
