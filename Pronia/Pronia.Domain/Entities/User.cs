using Microsoft.AspNetCore.Identity;
using Pronia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Domain.Entities;

public class User : IdentityUser
{
    //public User() => Orders = new HashSet<Order>();
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string FullName { get => FirstName + " " + LastName; }
    //public ICollection<Order> Orders { get; set; }
}
