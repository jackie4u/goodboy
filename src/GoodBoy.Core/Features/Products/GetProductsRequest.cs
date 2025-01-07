namespace GoodBoy.Core.Features.Products;

public class GetProductsRequest
{
    public const string RouteTemplate = "/api/products";

    public record Response(List<ProductDto> Products);
}