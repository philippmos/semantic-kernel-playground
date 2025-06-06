using TAIste.Plugins.Common;

namespace TAIste.Plugins.Common.Hosting;

public static class ApiWebApplication
{
    public static WebApplicationBuilder CreateBuilder(params string[] args)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { Args = args });

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddServices();

        builder.Services.SetupKernel(builder.Configuration, builder.Environment);

        builder.Configuration.AddEnvironmentVariables();

        builder.WebHost.UseUrls(string.Empty);
        builder.WebHost.UseKestrel(serverOptions =>
        {
            if (!int.TryParse(builder.Configuration["KestrelPort"], out var kestrelPort))
            {
                throw new Exception("Kestrel Port is not valid");
            }

            serverOptions.ListenAnyIP(kestrelPort);
        });

        return builder;
    }
}
