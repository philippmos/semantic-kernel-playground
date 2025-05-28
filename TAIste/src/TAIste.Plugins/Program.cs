using TAIste.Plugins.Common.Hosting;
using TAIste.Plugins.Endpoints;

var builder = ApiWebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapEndpoints();

app.Run();
