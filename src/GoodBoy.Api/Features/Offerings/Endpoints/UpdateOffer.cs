using FastEndpoints;
using GoodBoy.Api.Persistence.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Api.Features.Offerings.Endpoints;

[HttpPut("/offer")]
[AllowAnonymous]
public class UpdateOffer
{
    //Todo <medium>: Reimplement
    //if (_offerings.TryGetValue(newOffer.Id, out Offer oldOffer))
    //{
    //    // Key found, return the Offer
    //    // return Result.Ok(newOffer);
    //} else
    //{
    //    // Key not found
    //    // return Result.Fail<Offer, string>($"No newOffer found with ID: {id}");
    //}

    //_offerings[newOffer.Id] = newOffer;
    //return newOffer;
}
