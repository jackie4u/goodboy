using GoodBoy.Core.Enums;

namespace GoodBoy.Core.Features.Products;

public class ProductDto
{
    public int? ProductId { get; set; }
    public int? Id { get; set; }
    public string? Ean { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Quantity { get; set; } = 0;
    public Currencies Currency { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
    //public List<Categories?> Categories { get; set; } = new List<Categories?>();
    public string? Categories { get; set; } = string.Empty;
    public string? MainPicture { get; set; }
}
