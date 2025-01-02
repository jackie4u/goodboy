using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Web.Application.Features.Products.Endpoints;

[HttpGet("/product")]
[AllowAnonymous]
public class GetProductById
{
}
