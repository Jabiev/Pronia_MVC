using Pronia.Domain.Entities.Base;

namespace Pronia.Domain.Entities;

public class Post : BaseEntity
{
    //public Post() => Categories = new HashSet<Category>();

    public string CreatedBy { get; set; } = "BY Admin";
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string ImageUrl { get; set; } = null!;
    public PopularTag Tag { get; set; } = PopularTag.Organic;
    //public ICollection<Category> Categories { get; set; }
}
