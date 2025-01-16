using GoodBoy.Core.Features.Shared;

namespace GoodBoy.Core.Features.Products;
public class ImportProductsRequest
{
    public const string RouteTemplate = "/products/import";

    public string XmlContent { get; set; } = ""; // Use string for XML content instead of XmlDocument

    public record Response(bool Success = true, string? Message = null) : BaseResponse(Success, Message);
}