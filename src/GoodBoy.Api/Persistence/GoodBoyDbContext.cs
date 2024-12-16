using GoodBoy.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Api.Persistence;

public class GoodBoyDbContext(DbContextOptions<GoodBoyDbContext> options) : DbContext(options)
{
    public DbSet<Offer> Offerings { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Offer>(entity =>
        {
            entity.Property(e => e.Price)
                .HasColumnType("money");
        });
    }
}