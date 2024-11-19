using Pronia.Domain.Entities.Base;

namespace Pronia.Domain.Entities;

public class Testimonial : BaseEntity
{
    public string? Profil { get; set; }
    public string FullName { get; set; } = null!;
    public string Commentary { get; set; } = null!;
}
