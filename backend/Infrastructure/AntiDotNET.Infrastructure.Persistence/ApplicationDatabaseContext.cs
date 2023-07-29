using AntiDotNET.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AntiDotNET.Infrastructure.Persistence;

public class ApplicationDatabaseContext : IdentityDbContext<User>
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
    {
        
    }

}