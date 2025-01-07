namespace GoodBoy.Core.Features.Products;

public class CreateProductRequest
{
    public const string RouteTemplate = "/product";

    public ProductDto Product { get; set; } = new ProductDto(); // Initialize Product

    public record Response(int? ProductId);
}

