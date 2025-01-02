using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoodBoy.Core.Enums;

namespace GoodBoy.Web.Data.Entities;

public class Product
{
    public int ProductId { get; set; }
    public int? Id { get; set; }
    public string? Ean { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Quantity { get; set; } = 0;
    public Currencies Currency { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
    public List<Categories?> Categories { get; set; } = new List<Categories?>();
    public string? MainPicture { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductId);

        builder.Property(x => x.ProductId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Id)
            .ValueGeneratedNever(); // Prevent automatic generation for Id

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Ean)
            .HasMaxLength(13);

        builder.Property(x => x.Description)
            .HasMaxLength(4000);

        builder.Property(x => x.Currency)
            .HasConversion<string>()
            .HasMaxLength(3);

        builder.Property(x => x.Price)
            .HasColumnType("money");

        builder.Property(x => x.MainPicture)
            .HasMaxLength(200);

        builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedOn).HasDefaultValueSql("GETDATE()");
    }
}