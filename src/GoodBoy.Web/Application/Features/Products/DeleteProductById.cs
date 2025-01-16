using FastEndpoints;
using GoodBoy.Client.Features.Shared;
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
    private readonly ILogger<DeleteProductById> _logger;

    public DeleteProductById(ApplicationDbContext context, ILogger<DeleteProductById> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        string? _errorMessage;
        try
        {
            int id = Route<int>("Id");
            _logger.LogInformation("Deleting product with ID: {ProductId}", id);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
            }

            _logger.LogInformation($"Product with ID {id} deleted successfully.");
            await SendAsync(new DeleteProductByIdRequest.Response(), cancellation: cancellationToken);
        } catch (DbUpdateException ex)
        {
            _errorMessage = "Database update error.";
            _logger.LogError(ex, _errorMessage);
            var response = new DeleteProductByIdRequest.Response(false, $"{_errorMessage}: {ex.Message}");
            await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
        } catch (Exception ex)
        {
            _errorMessage = "An unexpected error occurred.";
            _logger.LogError(ex, _errorMessage);
            var response = new DeleteProductByIdRequest.Response(false, $"{_errorMessage}: {ex.Message}");
            await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}