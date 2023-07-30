using Microsoft.AspNetCore.Builder;

namespace AntiDotNET.Presentation.WebFramework.Middlewares.ExceptionHandling;

public static class WebApplicationExtension
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        return app;
    }
}