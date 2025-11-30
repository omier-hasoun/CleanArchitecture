

using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Web.Api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5000); // Http
                options.ListenAnyIP(5001, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2 | HttpProtocols.Http3;
                    listenOptions.UseHttps();
                });
            });

            builder.Configuration.AddUserSecrets("7f342e59-c0e1-4ef5-9bd1-126a96fa7a5b");

            var config = builder.Configuration;

            builder.Services.AddWebApiServices(config)
                            .AddApplicationServices(config)
                            .AddInfrastructureServices(config);

            var app = builder.Build();

            app.MapIdentityApi<User>();


            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
                app.MapGet("/", () => "Hello World!");
            }
            else
            {
                // app.UseHsts();
            }



            app.Run();
        }
    }
}
