namespace AntiDotNET.Application.Models.Identity.User;

public class RegisterUserDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
}