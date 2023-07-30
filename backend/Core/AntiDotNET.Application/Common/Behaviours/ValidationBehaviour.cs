using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace AntiDotNET.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var errors = new List<ValidationFailure>();

        foreach (var validator in _validators)
        {
            var validationResult =
                await validator.ValidateAsync(new ValidationContext<TRequest>(request), cancellationToken);

            if (!validationResult.IsValid)
            {
                errors.AddRange(validationResult.Errors);
            }
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}