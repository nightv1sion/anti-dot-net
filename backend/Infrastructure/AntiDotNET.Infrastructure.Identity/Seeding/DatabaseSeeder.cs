using AntiDotNET.Domain.Entities.Identity;
using AntiDotNET.Infrastructure.Identity.Constants;
using AntiDotNET.Infrastructure.Identity.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AntiDotNET.Infrastructure.Identity.Seeding;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public DatabaseSeeder(
        UserManager<User> userManager, 
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task SeedAsync()
    {
        await SeedUsersAsync();
        await SeedRolesAsync();
    }

    private async Task SeedRolesAsync()
    {
        if (!await _roleManager.Roles.AsNoTracking()
                .AnyAsync(role => role.Name != null && role.Name.Equals(RolesConstants.AdministratorRole)))
        {
            var role = new IdentityRole
            {
                Name = RolesConstants.AdministratorRole
            };

            await _roleManager.CreateAsync(role);
        }
        
        if (!await _roleManager.Roles.AsNoTracking()
                .AnyAsync(role => role.Name != null && role.Name.Equals(RolesConstants.ViewerRole)))
        {
            var role = new IdentityRole
            {
                Name = RolesConstants.ViewerRole
            };

            await _roleManager.CreateAsync(role);
        }
    }

    private async Task SeedUsersAsync()
    {
        var adminUsername = _configuration["Identity:Administrator:Username"];
        if (!await _userManager.Users.AsNoTracking()
                .AnyAsync(u => u.UserName != null && u.UserName.Equals(adminUsername)))
        {
            var user = new User
            {
                UserName = adminUsername,
                Email = _configuration["Identity:Administrator:Email"],
                PhoneNumberConfirmed = true
            };

            var result = await  _userManager.CreateAsync(user, _configuration["Identity:Administrator:Password"]!);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RolesConstants.AdministratorRole);
            }
            else
            {
                throw new InvalidOperationException(String.Join("",
                    result.Errors.Select(x => $"{x.Code}: {x.Description}")));
            }
        }
    }
}