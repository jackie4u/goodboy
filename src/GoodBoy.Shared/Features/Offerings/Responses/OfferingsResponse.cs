using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBoy.Shared.Features.Offerings.Responses;

public class OfferingsResponse
{
    public required IEnumerable<OfferResponse> Offerings { get; init; } = Enumerable.Empty<OfferResponse>();
}
