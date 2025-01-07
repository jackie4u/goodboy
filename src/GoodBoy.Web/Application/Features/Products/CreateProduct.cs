using FastEndpoints;
using GoodBoy.Web.Data;
using GoodBoy.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using GoodBoy.Core.Features.Products;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPost("/product")]
[AllowAnonymous]
public class CreateProduct : Endpoint<CreateProductRequest, CreateProductRequest.Response>
{
    private readonly ApplicationDbContext _context;

    public CreateProduct(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = request.Product.Id,
            Ean = request.Product.Ean,
            Name = request.Product.Name,
            Description = request.Product.Description,
            Quantity = request.Product.Quantity,
            Currency = request.Product.Currency,
            Price = request.Product.Price,
            Categories = request.Product.Categories,
            MainPicture = request.Product.MainPicture
        };

        await _context.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await SendAsync(new CreateProductRequest.Response(product.Id));
    }
}
