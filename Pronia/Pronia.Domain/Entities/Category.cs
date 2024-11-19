using Pronia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Domain.Entities;

public class Category : BaseEntity
{
    //public Category()
    //{
    //    Products = new HashSet<Product>();
    //    Posts = new HashSet<Post>();
    //}
    public string Name { get; set; } = null!;
    //public ICollection<Product> Products { get; set; }
    //public ICollection<Post> Posts { get; set; }
}
