using FastEndpoints;
using GoodBoy.Client.Features.Shared;
using GoodBoy.Core.Features.Products;
using GoodBoy.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Products;
[HttpGet(GetProductsRequest.RouteTemplate)]
[AllowAnonymous]
public class GetProducts : EndpointWithoutRequest<GetProductsRequest.Response>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetProducts> _logger;

    public GetProducts(ApplicationDbContext context, ILogger<GetProducts> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        string? _errorMessage;
        try
        {
            _logger.LogInformation("Fetching all products.");

            var products = await _context.Products
                .OrderBy(p => p.CreatedOn)
                .ToListAsync(cancellationToken);

            if (!products.Any())
            {
                _logger.LogWarning("No products found in the database.");
                await SendNotFoundAsync();
                return;
            }

            var response = new GetProductsRequest.Response(
                products
                    .Select(product => new ProductDto
                    {
                        Id = product.Id,
                        Ean = product.Ean,
                        Name = product.Name,
                        Description = product.Description,
                        Quantity = product.Quantity,
                        Currency = product.Currency,
                        Price = product.Price,
                        Categories = product.Categories,
                        MainPicture = product.MainPicture
                    }).ToList()
                );

            _logger.LogInformation("Successfully fetched {ProductCount} products.", products.Count);
            await SendAsync(response);
        } catch (Exception ex)
        {
            _errorMessage = "An unexpected error occurred.";
            _logger.LogError(ex, _errorMessage);
            var response = new GetProductsRequest.Response(null, false, $"{_errorMessage}: {ex.Message}");
            await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}