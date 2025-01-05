
namespace GoodBoy.Core.Features.Products.Requests;

public class CreateProductRequest
{
    public const string RouteTemplate = "/product";

    public ProductDto Product { get; set; } = new ProductDto(); // Initialize Product

    public record Response(int? ProductId);
}

