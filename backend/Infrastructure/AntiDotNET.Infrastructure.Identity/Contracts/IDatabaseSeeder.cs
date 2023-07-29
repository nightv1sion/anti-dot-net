namespace AntiDotNET.Infrastructure.Identity.Contracts;

public interface IDatabaseSeeder
{
    Task SeedAsync();
}