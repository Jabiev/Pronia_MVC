using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pronia.Domain.Entities;
using Pronia.Domain.Entities.Base;

namespace Pronia.Data.Contexts;

public class ProniaDbContext : IdentityDbContext<User>
{
    public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options)
    {
    }
    public DbSet<Biography> Biography { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<Testimonial> Testimonials { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(7, 2);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = DateTime.UtcNow;
            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedDate = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
