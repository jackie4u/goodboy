namespace GoodBoy.Core.Features.Products;

public class GetProductsRequest
{
    public const string RouteTemplate = "/products";

    public record Response(List<ProductDto> Products);
}