using AntiDotNET.Application.Contracts.Identity;
using AntiDotNET.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace AntiDotNET.Infrastructure.Identity.ServiceManagers;

public class UserManagerService : IUserManagerService
{
    private readonly UserManager<User> _userManager;
    
    public UserManagerService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }   
}