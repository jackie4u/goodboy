using System.Threading;
using FastEndpoints;
using GoodBoy.Api.Persistence;
using GoodBoy.Shared.Features.Offerings.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Api.Features.Offerings.Endpoints;

[HttpGet("/offerings")]
[AllowAnonymous]
public class GetOfferings : EndpointWithoutRequest<OfferingsResponse>
{
    private readonly GoodBoyDbContext _context;

    public GetOfferings(GoodBoyDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var offerings = await _context.Offerings
            .Select(offer => new OfferResponse
            {
                Id = offer.Id,
                Name = offer.Name,
                Description = offer.Description,
                Price = offer.Price,
                Quantity = offer.Quantity,
            })
            .ToListAsync(cancellationToken);

        await SendAsync(new OfferingsResponse { Offerings = offerings });
    }
}