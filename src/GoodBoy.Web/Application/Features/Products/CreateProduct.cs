using FastEndpoints;
using GoodBoy.Web.Data;
using GoodBoy.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using GoodBoy.Core.Features.Products;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPost(EditProductRequest.RouteTemplate)]
[AllowAnonymous]
public class CreateProduct : Endpoint<EditProductRequest, EditProductRequest.Response>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CreateProduct> _logger;

    public CreateProduct(ApplicationDbContext context, ILogger<CreateProduct> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
    {
        string? _errorMessage;
        try
        {
            _logger.LogInformation($"Creating a new product with Id {request.Product.Id} and name: {request.Product.Name}");

            // Note: Checks for updating Id should be handled on UI
            var product = request.Product.MapNewEntity();

            await _context.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            if (product.Id == null)
            {
                product.Id = product.ProductId;
                await _context.SaveChangesAsync(cancellationToken);
            }

            _logger.LogInformation($"Product with ID {product.Id} created successfully.");
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