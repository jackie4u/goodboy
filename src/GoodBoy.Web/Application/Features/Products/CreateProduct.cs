using FastEndpoints;
using GoodBoy.Web.Data;
using GoodBoy.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using GoodBoy.Core.Features.Products;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPost(EditProductRequest.RouteTemplate)]
[AllowAnonymous]
public class CreateProduct : Endpoint<EditProductRequest, EditProductRequest.Response>
{
    private readonly ApplicationDbContext _context;

    public CreateProduct(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
    {
        var product = request.Product.MapNewEntity();

        await _context.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await SendAsync(new EditProductRequest.Response(product.Id));
    }
}