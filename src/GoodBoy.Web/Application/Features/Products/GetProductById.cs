﻿using FastEndpoints;
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

    public GetProductById(ApplicationDbContext context)
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

            var response = new GetProductByIdRequest.Response(
                new ProductDto
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
                }
            );

            await SendAsync(response);

        } catch (Exception ex)
        {
            // Todo<Medium>: Log the exception (using a logging framework like Serilog or NLog)
            //_logger.LogError(ex, "An error occurred while fetching product.");

            await SendErrorsAsync();
        }
    }
}
