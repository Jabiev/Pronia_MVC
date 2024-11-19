using Pronia.Domain.Entities.Base;

namespace Pronia.Domain.Entities;

public class Slider : BaseEntity
{
    public string Offer { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}
