using Pronia.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Domain.Entities;

public class Order : BaseEntity
{
    //public Order() => Products = new HashSet<Product>();

    //[StringLength(5)]
    public string UniqueCode { get; set; } = null!;
    public decimal Total { get; set; }
    public Status Status { get; set; } = Status.OnHold;
    //public User? User { get; set; }
    //public ICollection<Product> Products { get; set; }
}
