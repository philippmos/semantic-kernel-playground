namespace SemanticKernelPlugins.Endpoints;

public static class EndpointMapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapOpenAiEndpoints();
    }
}
