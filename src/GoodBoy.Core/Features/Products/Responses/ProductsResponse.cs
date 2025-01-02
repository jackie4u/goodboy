using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBoy.Core.Features.Offerings.Responses;

public class ProductsResponse
{
    public required IEnumerable<ProductResponse> Offerings { get; init; } = Enumerable.Empty<ProductResponse>();
}
