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
    private readonly ILogger<ImportProducts> _logger;

    public CreateProduct(ApplicationDbContext context, ILogger<ImportProducts> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(EditProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Creating a new product with Id {request.Product.Id} and name: {request.Product.Name}");

            // Note: Check for Id should be handled on UI
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
            _logger.LogError(ex, "Database update error during product creation.");
            await SendAsync(new EditProductRequest.Response(null), cancellation: cancellationToken);
        } catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during product creation.");
            await SendAsync(new EditProductRequest.Response(null), cancellation: cancellationToken);
        }
    }
}