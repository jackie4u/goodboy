using GoodBoy.Core.Features.Shared;

namespace GoodBoy.Core.Features.Products;

public class GetProductByIdRequest
{
    public const string RouteTemplate = "/api/product";

    public record Response(ProductDto? Product, bool Success = true, string? Message = null) : BaseResponse(Success, Message);
}
