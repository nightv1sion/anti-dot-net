using AntiDotNET.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AntiDotNET.Infrastructure.Persistence.ServiceConfiguration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureDatabaseContext(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDatabaseContext>(
            x => x.UseNpgsql(configuration["ConnectionStrings:PostgresConnection"]));

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationDatabaseContext>();
        
        return services;
    }
}