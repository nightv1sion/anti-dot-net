using AntiDotNET.Application.Features.Identity.User.Commands.RegisterUser;
using AntiDotNET.Application.Models.Identity.User;
using AntiDotNET.Presentation.WebFramework.BaseController;
using AntiDotNET.Presentation.WebFramework.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AntiDotNET.Presentation.WebAPI.Controllers.V1.Identity;

[ApiVersion("1")]
[ApiController]
[Route("api/users")]
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserDto dto)
    {
        var commandResult = await _mediator.Send(new RegisterUserCommand(dto));
        return OperationResult(commandResult);
    }
}