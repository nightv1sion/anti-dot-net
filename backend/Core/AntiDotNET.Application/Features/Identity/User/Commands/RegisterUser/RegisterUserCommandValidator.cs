using FluentValidation;

namespace AntiDotNET.Application.Features.Identity.User.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.User.Username)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have username");

        RuleFor(x => x.User.Mail)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .WithMessage("User must have valid mail");

        RuleFor(x => x.User.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have first name");
        
        RuleFor(x => x.User.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("User must have first name");

        RuleFor(x => x.User.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .WithMessage("User must have an eight-character password");
    }
}