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
    private readonly ILogger<ImportProducts> _logger;

    public UpdateProduct(ApplicationDbContext context, ILogger<ImportProducts> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Updating product with ID: {ProductId}", request.Product.ProductId);

            var product = await _context.Products
            .FindAsync(request.Product.ProductId);

            if (product == null)
            {
                _logger.LogWarning($"Product with ID {request.Product.ProductId} not found.");
                await SendNotFoundAsync();
                return;
            }

            var updatedHoursAgo = (DateTime.UtcNow - product.UpdatedOn).TotalHours;
            if (product.Price != request.Product.Price && updatedHoursAgo < 12)
            {
                _logger.LogError($"It is not possible to update price more than once in 12 hours. Update price will be possible again after {product.UpdatedOn.AddHours(12)}.");
                await SendErrorsAsync();
                return;
            }

            request.Product.MapCurrentEntity(product);

            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Product with ID {product.Id} updated successfully.");

            await SendAsync(new EditProductRequest.Response(product.Id));
        } catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "Concurrency error during product update.");
            await SendErrorsAsync();
        } catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database update error during product update.");
            await SendErrorsAsync();
        } catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during product update.");
            await SendErrorsAsync();
        }
    }
}