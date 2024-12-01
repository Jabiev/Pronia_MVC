using Microsoft.AspNetCore.Identity;

namespace Pronia.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string FullName { get => FirstName + " " + LastName; }
}
