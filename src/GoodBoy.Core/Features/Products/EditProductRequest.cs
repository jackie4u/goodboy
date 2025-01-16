using GoodBoy.Core.Features.Shared;

namespace GoodBoy.Core.Features.Products;

public class EditProductRequest
{
    public const string RouteTemplate = "/api/product";

    public ProductDto Product { get; set; } = new ProductDto();

    public record Response(int? Id, bool Success = true, string? Message = null) : BaseResponse(Success, Message);
}