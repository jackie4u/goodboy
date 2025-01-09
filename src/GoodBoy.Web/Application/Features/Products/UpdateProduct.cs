using FastEndpoints;
using GoodBoy.Web.Data;
using GoodBoy.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using GoodBoy.Core.Features.Products;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPut(EditProductRequest.RouteTemplate)]
[AllowAnonymous]
public class UpdateProduct : Endpoint<EditProductRequest, EditProductRequest.Response>
{
    private readonly ApplicationDbContext _context;

    public UpdateProduct(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FindAsync(request.Product.Id);

        if (product == null)
        {
            await SendNotFoundAsync();
            return;
        }

        request.Product.MapCurrentEntity(product);

        await _context.SaveChangesAsync(cancellationToken);

        await SendAsync(new EditProductRequest.Response(product.Id));
    }
}
