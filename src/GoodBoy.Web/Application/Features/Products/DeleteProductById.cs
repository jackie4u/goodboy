using FastEndpoints;
using GoodBoy.Core.Features.Products;
using GoodBoy.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Web.Application.Features.Products;

[HttpDelete($"{DeleteProductByIdRequest.RouteTemplate}/{{Id:int}}")]
[AllowAnonymous]
public class DeleteProductById : EndpointWithoutRequest
{
    private readonly ApplicationDbContext _context;

    public DeleteProductById(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        try
        {
            int id = Route<int>("Id");

            var product = await _context.Products
                .FindAsync(id);

            if (product == null)
            {
                await SendNotFoundAsync();
                return;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            await SendOkAsync();

        } catch (Exception ex)
        {
            // Todo<Medium>: Log the exception (using a logging framework like Serilog or NLog)
            //_logger.LogError(ex, "An error occurred while fetching product.");

            await SendErrorsAsync();
        }
    }
}