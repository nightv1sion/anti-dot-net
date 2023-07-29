using AntiDotNET.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace AntiDotNET.Domain.Entities.Identity;

public class User : IdentityUser, IEntity<string>
{
    
}