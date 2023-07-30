using System.Text.Json;
using AntiDotNET.Common.Extensions;
using AntiDotNET.Presentation.WebFramework.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AntiDotNET.Presentation.WebFramework.Middlewares.ExceptionHandling;

public class ExceptionHandlerMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            var errors = new Dictionary<string, List<string>>();

            foreach (var error in exception.Errors)
            {
                if (errors.TryGetValue(error.PropertyName, out var errorList))
                {
                    errorList.Add(error.ErrorMessage);
                }
                else
                {
                    errors.Add(error.PropertyName, new List<string> { error.ErrorMessage });
                }
            }

            var requestApiResult = new RequestApiResult<Dictionary<string, List<string>>>(
                false, StatusCodes.Status422UnprocessableEntity, errors);

            var jsonResult = requestApiResult.ToPrettyJson();

            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(jsonResult);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new RequestApiResult(false, StatusCodes.Status500InternalServerError, "Server Error");
            var jsonResponse = response.ToPrettyJson();
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}