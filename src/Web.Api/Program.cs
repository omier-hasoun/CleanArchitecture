
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets("7f342e59-c0e1-4ef5-9bd1-126a96fa7a5b");

var config = builder.Configuration;

builder.Services.AddWebApiServices(config)
                .AddApplicationServices(config)
                .AddInfrastructureServices(config);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
