using System.Collections.Concurrent;
using GoodBoy.Api.Persistence.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace GoodBoy.Api.Features.Offerings;

public class OfferService
{
    private readonly ConcurrentDictionary<int, Offer> _offerings = new();

    public OfferService()
    {
    }

    public Task<Offer?> GetByIdAsync(int id)
    {
        return Task.FromResult(_offerings.GetValueOrDefault(id));
    }

    public Task<IEnumerable<Offer>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Offer>>(_offerings.Values);
    }

    public async Task<Offer> CreateAsync(Offer offer)
    {

        //if (1 == 2)
        //{
        //    var error = "This newOffer already exists in the system";
        //    retunr 
        //}

        _offerings[offer.Id] = offer;

        return offer;
    }

    public async Task<Offer> UpdateAsync(Offer newOffer)
    {
        //Todo <medium>: Reimplement
        if (_offerings.TryGetValue(newOffer.Id, out Offer oldOffer))
        {
            // Key found, return the Offer
            // return Result.Ok(newOffer);
        } else
        {
            // Key not found
            // return Result.Fail<Offer, string>($"No newOffer found with ID: {id}");
        }

        _offerings[newOffer.Id] = newOffer;
        return newOffer;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        _offerings.Remove(id, out var offer);
        if (offer is null)
        {
            return false;
        }

        return true;
    }
}
