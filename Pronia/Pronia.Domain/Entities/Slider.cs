using Pronia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Domain.Entities;

public class Slider : BaseEntity
{
    [Required(ErrorMessage = "Please Enter Value")]
    public string Offer { get; set; } = null!;

    [Required(ErrorMessage = "Please Enter Value"),StringLength(80)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Please Enter Value"), StringLength(200)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Please Enter Value")]
    public string ImageUrl { get; set; } = null!;
}
