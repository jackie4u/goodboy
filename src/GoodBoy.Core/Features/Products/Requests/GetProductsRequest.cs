using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GoodBoy.Core.Features.Products.Requests;

public class GetProductsRequest : IRequest<GetProductsRequest.Response>
{
    public record Response(IEnumerable<ProductDto> Products);
}