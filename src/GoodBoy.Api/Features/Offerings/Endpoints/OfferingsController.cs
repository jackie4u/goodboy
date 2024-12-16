using GoodBoy.Api.Persistence;
using GoodBoy.Api.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Api.Features.Offerings.Endpoints;

[ApiController]
[Route("[controller]")]
public class OfferingsController : ControllerBase
{
    private readonly ILogger<OfferingsController> _logger;
    private readonly GoodBoyDbContext _context;

    public OfferingsController(ILogger<OfferingsController> logger, GoodBoyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    private static readonly string[] Names = new[]
    {
        "Fluffy Chew Toy", "Squeaky Bone", "Durable Ball", "Plush Bed", "Tasty Treats"
    };

    private static readonly string[] Descriptions = new[]
    {
        "Perfect for cuddling and chewing.", "Satisfies your dog's natural instincts.", "Great for fetch and playtime.", "Provides ultimate comfort and support.", "Delicious and nutritious snacks."
    };

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Offer> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Offer
        {
            Id = index,
            Name = Names[Random.Shared.Next(Names.Length)],
            Description = Descriptions[Random.Shared.Next(Descriptions.Length)],
            Quantity = Random.Shared.Next(0, 100),
            Price = (decimal) (Random.Shared.NextDouble() * 100) // Price between 0 and 100
        })
        .ToArray();
    }
}
