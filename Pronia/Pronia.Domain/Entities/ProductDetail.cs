using Pronia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Domain.Entities;

public class ProductDetail : BaseEntity
{
    //[StringLength(8)]
    public string SKU { get; set; } = null!;
    public int ProductId { get; set; }
    public string? Description { get; set; }

    public Color? Color { get; set; } = Domain.Color.Black;
    public PopularTag? Tag { get; set; } = PopularTag.Organic;
    public Size? Size { get; set; } = Domain.Size.MediumSizeAndPoot;
    //public Product? Product { get; set; }
}
