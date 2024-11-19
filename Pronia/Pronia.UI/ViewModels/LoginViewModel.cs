using System.ComponentModel.DataAnnotations;

namespace Pronia.UI.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "LastName is required")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember Me ?")]
    public bool RememberMe { get; set; }
}