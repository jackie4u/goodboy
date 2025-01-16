using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodBoy.Core.Features.Shared;

namespace GoodBoy.Core.Features.Products;

public class DeleteProductByIdRequest
{
    public const string RouteTemplate = "/api/product";
    public record Response(bool Success = true, string? Message = null) : BaseResponse(Success, Message);
}
