using AntiDotNET.Application.Models.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AntiDotNET.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var response = await next();
            return response;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            if (typeof(TResponse).GetGenericTypeDefinition() == typeof(OperationResult<>))
            {
                dynamic response = new OperationResult
                {
                    IsException = true
                };
                
                return response;
            }

            return default!;
        }
    }
}