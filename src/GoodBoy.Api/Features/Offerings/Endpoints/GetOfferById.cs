using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Api.Features.Offerings.Endpoints;

[HttpGet("/offer")]
[AllowAnonymous]
public class GetOfferById
{
}
