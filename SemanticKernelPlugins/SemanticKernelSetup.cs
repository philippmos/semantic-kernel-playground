using Microsoft.SemanticKernel;
using OllamaApiFacade.Extensions;
using SemanticKernelPlugins.Plugins;

namespace SemanticKernelPlugins;

public static class SemanticKernelSetup
{
    public static IServiceCollection SetupKernel(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddKernel()
            .AddLmStudio(endpoint: configuration["LmStudioUrl"] ?? throw new Exception("LmStudioUrl is empty"))
            .AddPlugins();

        return services;
    }

    public static IKernelBuilder AddPlugins(this IKernelBuilder builder)
    {
        builder.Plugins.AddFromType<TimeInformationPlugin>();

        return builder;
    }
}
