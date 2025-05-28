using SemanticKernelPlugins.Common.Hosting;
using SemanticKernelPlugins.Endpoints;

var builder = ApiWebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapEndpoints();

app.Run();
