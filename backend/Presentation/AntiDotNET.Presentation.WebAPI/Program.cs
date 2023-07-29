using AntiDotNET.Presentation.WebAPI.Configuration;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureWebApplicationBuilder();

var app = await builder
    .Build()
    .ConfigureWebApplication();

await app.RunAsync();