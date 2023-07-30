using AntiDotNET.Infrastructure.Identity.Contracts;
using AntiDotNET.Infrastructure.Persistence;
using AntiDotNET.Presentation.WebFramework.Middlewares.ExceptionHandling;
using Microsoft.EntityFrameworkCore;

namespace AntiDotNET.Presentation.WebAPI.Configuration;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> ConfigureWebApplication(this WebApplication app)
    {
        await app.SeedDatabaseAsync();
       
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandlingMiddleware();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        return app;
    }
    private static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }

        var databaseSeeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
        await databaseSeeder.SeedAsync();
        
        return app;
    }
}