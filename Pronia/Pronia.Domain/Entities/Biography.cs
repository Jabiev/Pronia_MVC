using Pronia.Domain.Entities.Base;

namespace Pronia.Domain.Entities;

public class Biography : BaseEntity
{
    public string? Icon { get; set; }
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}
