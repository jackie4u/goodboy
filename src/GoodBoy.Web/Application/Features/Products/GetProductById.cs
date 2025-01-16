using FastEndpoints;
using GoodBoy.Core.Features.Products;
using GoodBoy.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Products;

[HttpGet($"{GetProductByIdRequest.RouteTemplate}/{{Id:int}}")]
[AllowAnonymous]
public class GetProductById : EndpointWithoutRequest<GetProductByIdRequest.Response>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GetProductById> _logger;

    public GetProductById(ApplicationDbContext context, ILogger<GetProductById> logger)
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
            _logger.LogInformation($"Fetching product with ID: {id}");

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                await SendNotFoundAsync();
                return;
            }

            var response = new GetProductByIdRequest.Response(
                new ProductDto
                {
                    ProductId = product.ProductId,
                    Id = product.Id,
                    Ean = product.Ean,
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    Currency = product.Currency,
                    Price = product.Price,
                    Categories = product.Categories,
                    MainPicture = product.MainPicture
                }
            );

            _logger.LogInformation($"Product with ID {id} fetched successfully.");
            await SendAsync(response);
        } catch (Exception ex)
        {
            _errorMessage = "An unexpected error occurred.";
            _logger.LogError(ex, _errorMessage);
            var response = new GetProductByIdRequest.Response(null, false, $"{_errorMessage}: {ex.Message}");
            await SendAsync(response, cancellation: cancellationToken, statusCode: StatusCodes.Status400BadRequest);
        }
    }
}
