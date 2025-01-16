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
    private readonly ILogger<UpdateProduct> _logger;

    public UpdateProduct(ApplicationDbContext context, ILogger<UpdateProduct> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
    {
        string? _errorMessage;
        try
        {
            _logger.LogInformation("Updating product with ID: {ProductId}", request.Product.ProductId);

            var product = await _context.Products
            .FindAsync(request.Product.ProductId);

            if (product == null)
            {
                _errorMessage = $"Product with ID {request.Product.ProductId} not found.";
                _logger.LogWarning(_errorMessage);
                var response = new EditProductRequest.Response(null, false, _errorMessage);
                await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status404NotFound);
                return;
            }

            var updatedHoursAgo = (DateTime.UtcNow - product.UpdatedOn).TotalHours;
            if (product.Price != request.Product.Price && updatedHoursAgo < 12)
            {
                _errorMessage = $"It is not possible to update price more than once in 12 hours. " +
                                   $"Update price will be possible again after {product.UpdatedOn.AddHours(12)}.";

                _logger.LogError(_errorMessage);
                var response = new EditProductRequest.Response(null, false, _errorMessage);
                await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
                return;
            }

            request.Product.MapCurrentEntity(product);

            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Product with ID {product.Id} updated successfully.");

            await SendAsync(new EditProductRequest.Response(product.Id));
        } catch (DbUpdateException ex)
        {
            _errorMessage = "Database update error.";
            _logger.LogError(ex, _errorMessage);
            var response = new EditProductRequest.Response(null, false, $"{_errorMessage}: {ex.Message}");
            await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
        } catch (Exception ex)
        {
            _errorMessage = "An unexpected error occurred.";
            _logger.LogError(ex, _errorMessage);
            var response = new EditProductRequest.Response(null, false, $"{_errorMessage}: {ex.Message}");
            await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}