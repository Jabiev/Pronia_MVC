using Pronia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Domain.Entities;

public class Product : BaseEntity
{
    //public Product()
    //{
    //    Categories = new HashSet<Category>();
    //    Orders = new HashSet<Order>();
    //}

    public string PrimaryImageUrl { get; set; } = null!;
    public string? SecondImageUrl { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsInStock { get; set; }
    public bool IsFeatured { get; set; }
    public int Star { get; set; }
    //public ProductDetail? ProductDetail { get; set; }
    //public ICollection<Category> Categories { get; set; }
    //public ICollection<Order> Orders { get; set; }

}
