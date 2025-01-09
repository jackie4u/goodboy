using GoodBoy.Core.Enums;
using GoodBoy.Core.Features.Products;
using GoodBoy.Web.Data;
using GoodBoy.Web.Data.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPost(ImportProductsRequest.RouteTemplate)]
[AllowAnonymous]
public class ImportProducts : Endpoint<ImportProductsRequest, ImportProductsRequest.Response>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ImportProducts> _logger;

    public ImportProducts(ApplicationDbContext context,ILogger<ImportProducts> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task HandleAsync(ImportProductsRequest req, CancellationToken cancellationToken)
    {
        try
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(req.XmlContent);

            var xmlProductNodes = xmlDocument.SelectNodes("/products/product");
            if (xmlProductNodes == null)
            {
                await SendAsync(new ImportProductsRequest.Response(false, "Invalid XML format."));
                return;
            }

            var xmlProductDtos = xmlProductNodes
                .Cast<XmlNode>()
                .Select(ProductMapper.MapFromXmlNode)
                .ToList();

            var xmlProductIds = xmlProductDtos.Select(dto => dto.Id ?? 0).ToList();

            // Get all existing product based on imported Ids from the Db
            var existingProducts = await _context.Products
                .Where(p => xmlProductIds.Contains(p.Id ?? 0))
                .ToDictionaryAsync(p => p.Id ?? 0, cancellationToken);

            foreach (var xmlProductDto in xmlProductDtos)
            {
                var product = existingProducts.GetValueOrDefault(xmlProductDto.Id ?? 0);

                if (product != null)
                {
                    xmlProductDto.MapCurrentEntity(product);
                } else
                {
                    var newProduct = xmlProductDto.MapNewEntity();
                    _context.Products.Add(newProduct);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            await SendAsync(new ImportProductsRequest.Response(true, "Products imported successfully."));

        } catch (XmlException ex)
        {
            _logger.LogError(ex, "Invalid XML format during product import.");
            await SendAsync(new ImportProductsRequest.Response(false, "Invalid XML format."));
        } catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database update error during product import.");
            await SendAsync(new ImportProductsRequest.Response(false, "Database update failed."));
        } catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during product import.");
            await SendAsync(new ImportProductsRequest.Response(false, $"Import failed: {ex.Message}"));
        }
    }
}