using System.Reflection;
using AntiDotNET.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace AntiDotNET.Application.Configuration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                options
                    .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
                    .AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            });
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}