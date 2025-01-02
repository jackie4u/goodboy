using System.Threading;
using FastEndpoints;
using GoodBoy.Core.Features.Products;
using GoodBoy.Core.Features.Products.Requests;
using GoodBoy.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Productings.Endpoints;

[HttpGet("/products")]
[AllowAnonymous]
public class GetProducts : EndpointWithoutRequest<GetProductsRequest.Response>
{
    private readonly ApplicationDbContext _context;

    public GetProducts(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .OrderBy(p => p.CreatedOn)
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Ean = product.Ean,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Currency = product.Currency,
                Price = product.Price,
                Categories = product.Categories,
                MainPicture = product.MainPicture
            })
            .ToListAsync(cancellationToken);

        var response = new GetProductsRequest.Response(products);

        await SendAsync(response);
    }
}