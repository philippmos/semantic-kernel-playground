using SemanticKernelPlugins.Endpoints;
using SemanticKernelPlugins.Hosting;

var builder = ApiWebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapEndpoints();

app.Run();
