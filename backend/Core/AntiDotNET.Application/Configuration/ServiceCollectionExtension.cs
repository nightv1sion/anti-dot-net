using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
namespace AntiDotNET.Application.Configuration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.Lifetime = ServiceLifetime.Scoped;
        });
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}