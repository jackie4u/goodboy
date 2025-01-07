namespace GoodBoy.Core.Features.Products;

public class GetProductByIdRequest
{
    public const string RouteTemplate = "/api/product";

    public record Response(ProductDto Product);
}
