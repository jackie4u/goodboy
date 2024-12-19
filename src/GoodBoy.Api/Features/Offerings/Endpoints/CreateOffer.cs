using FastEndpoints;
using GoodBoy.Api.Persistence;
using GoodBoy.Api.Persistence.Entities;
using GoodBoy.Shared.Features.Offerings.Requests;
using GoodBoy.Shared.Features.Offerings.Responses;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Api.Features.Offerings.Endpoints;

[HttpPost("/offer")]
[AllowAnonymous]
public class CreateOffer : Endpoint<CreateOfferRequest, int>
{
    private readonly GoodBoyDbContext _context;

    public CreateOffer(GoodBoyDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CreateOfferRequest createOfferRequest, CancellationToken cancellationToken)
    {
        //    var error = "This newOffer already exists in the system";
        //    return 
        var offer = new Offer
        {
            Name = createOfferRequest.Name,
            Description = createOfferRequest.Description,
            Price = createOfferRequest.Price,
            Quantity = createOfferRequest.Quantity,
        };

        await _context.AddAsync(offer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await SendAsync(offer.Id);
    }
}
