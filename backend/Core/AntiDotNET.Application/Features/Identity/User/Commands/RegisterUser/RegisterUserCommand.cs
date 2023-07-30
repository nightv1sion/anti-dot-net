using AntiDotNET.Application.Models.Common;
using AntiDotNET.Application.Models.Identity.User;
using MediatR;

namespace AntiDotNET.Application.Features.Identity.User.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<OperationResult<Guid>>
{
    public RegisterUserDto User { get; }

    public RegisterUserCommand(
        RegisterUserDto user)
    {
        User = user;
    }
}