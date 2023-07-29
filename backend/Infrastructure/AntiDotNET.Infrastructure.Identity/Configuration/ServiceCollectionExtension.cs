using AntiDotNET.Domain.Entities.Identity;
using AntiDotNET.Infrastructure.Identity.Contracts;
using AntiDotNET.Infrastructure.Identity.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AntiDotNET.Infrastructure.Identity.Configuration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterIdentityServices(
        this IServiceCollection services)
    {
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
        services.AddScoped<RoleManager<User>>();
        services.AddScoped<UserManager<IdentityRole>>();
        
        return services;
    }
}