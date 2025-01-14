using FastEndpoints;
using GoodBoy.Core.Features.Products;
using GoodBoy.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Products;

[HttpDelete($"{DeleteProductByIdRequest.RouteTemplate}/{{Id:int}}")]
[AllowAnonymous]
public class DeleteProductById : EndpointWithoutRequest
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ImportProducts> _logger;

    public DeleteProductById(ApplicationDbContext context, ILogger<ImportProducts> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        try
        {
            int id = Route<int>("Id");
            _logger.LogInformation("Deleting product with ID: {ProductId}", id);

            var product = await _context.Products
                .FindAsync(id);

            if (product == null)
            {
                await SendNotFoundAsync();
                return;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Product with ID {id} deleted successfully.");
            await SendOkAsync();
        } catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database update error during product deletion.");
            await SendErrorsAsync();
        } catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during product deletion.");
            await SendErrorsAsync();
        }
    }
}