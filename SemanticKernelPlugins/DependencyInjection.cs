using SemanticKernelPlugins.Services;
using SemanticKernelPlugins.Services.Interfaces;

namespace SemanticKernelPlugins;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IRecipeService, RecipeService>();

        return services;
    }
}
