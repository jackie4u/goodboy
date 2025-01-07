namespace GoodBoy.Core.Features.Products;

public class EditProductRequest
{
    public const string RouteTemplate = "/api/product";

    public ProductDto Product { get; set; } = new ProductDto();

    public record Response(int? Id);
}