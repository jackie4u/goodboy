using GoodBoy.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace GoodBoy.Web.Application.Features.Products;

public interface IImportProductsService
{
    Task<(bool Success, string? Message)> ImportProductsAsync(string xmlContent, CancellationToken cancellationToken);
}

public class ImportProductsService : IImportProductsService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ImportProductsService> _logger;

    public ImportProductsService(ApplicationDbContext context, ILogger<ImportProductsService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<(bool Success, string? Message)> ImportProductsAsync(string xmlContent, CancellationToken cancellationToken)
    {
        try
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);

            var xmlProductNodes = xmlDocument.SelectNodes("/products/product");
            if (xmlProductNodes == null)
            {
                return (false, "Invalid XML format.");
            }

            var xmlProductDtos = xmlProductNodes
                .Cast<XmlNode>()
                .Select(ProductMapper.MapFromXmlNode)
                .ToList();

            var xmlProductIds = xmlProductDtos.Select(dto => dto.Id ?? 0).ToList();

            var existingProducts = await _context.Products
                .Where(p => xmlProductIds.Contains(p.Id ?? 0))
                .AsNoTracking()
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
            return (true, "Products imported successfully.");
        } catch (XmlException ex)
        {
            _logger.LogError(ex, "Invalid XML format during product import.");
            return (false, "Invalid XML format.");
        } catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database update error during product import.");
            return (false, "Database update failed.");
        } catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred during product import.");
            return (false, $"Import failed: {ex.Message}");
        }
    }
}
