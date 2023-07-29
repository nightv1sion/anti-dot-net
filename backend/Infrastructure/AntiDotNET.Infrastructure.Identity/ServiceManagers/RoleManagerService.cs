using AntiDotNET.Application.Contracts.Identity;
using AntiDotNET.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace AntiDotNET.Infrastructure.Identity.ServiceManagers;

public class RoleManagerService : IRoleManagerService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagerService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
}