using System.ComponentModel.DataAnnotations;

namespace Pronia.UI.Areas.ainorp.ViewModels;

public class SliderViewModel
{
    [Required(ErrorMessage = "Please Enter Value")]
    public string Offer { get; set; } = null!;

    [Required(ErrorMessage = "Please Enter Value"), StringLength(80)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Please Enter Value"), StringLength(200)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Please Choose Image File")]
    public IFormFile Image { get; set; } = null!;
}
