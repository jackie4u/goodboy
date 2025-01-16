using GoodBoy.Core.Features.Shared;

namespace GoodBoy.Core.Features.Products;

public class GetProductsRequest
{
    public const string RouteTemplate = "/api/products";

    public record Response(List<ProductDto>? Products, bool Success = true, string? Message = null) : BaseResponse(Success, Message);
}