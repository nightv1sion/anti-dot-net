using AntiDotNET.Infrastructure.Identity.Configuration;
using AntiDotNET.Infrastructure.Persistence.ServiceConfiguration;

namespace AntiDotNET.Presentation.WebAPI.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureWebApplicationBuilder(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.ConfigureDatabaseContext(builder.Configuration);
        builder.Services.RegisterIdentityServices();

        return builder;
    }
}