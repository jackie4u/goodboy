
namespace GoodBoy.Core.Features.Products.Requests;

public class GetProductsRequest
{
    public const string RouteTemplate = "/products";

    public record Response(IEnumerable<ProductDto> Products);
}