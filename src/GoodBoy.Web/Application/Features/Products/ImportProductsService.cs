using GoodBoy.Core.Features.Products;
using GoodBoy.Core.Features.Shared;
using GoodBoy.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace GoodBoy.Web.Application.Features.Products;

public interface IImportProductsService
{
    Task<BaseResponse> ImportProductsAsync(string xmlContent, CancellationToken cancellationToken);
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

    public async Task<BaseResponse> ImportProductsAsync(string xmlContent, CancellationToken cancellationToken)
    {
        string? _errorMessage;
        try
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);

            var xmlProductNodes = xmlDocument.SelectNodes("/products/product");
            if (xmlProductNodes == null)
            {
                _errorMessage = "No XML data found.";
                _logger.LogWarning(_errorMessage);
                return new BaseResponse { 
                    Success = false, 
                    Message = _errorMessage
                };
            }

            var xmlProductDtos = xmlProductNodes
                .Cast<XmlNode>()
                .Select(ProductMapper.MapFromXmlNode)
                .ToList();

            var xmlProductIds = xmlProductDtos.Select(dto => dto.Id ?? 0).ToList();

            var existingProducts = await _context.Products
                .Where(p => xmlProductIds.Contains(p.Id ?? 0))
                .ToDictionaryAsync(p => p.Id ?? 0, cancellationToken);

            foreach (var xmlProductDto in xmlProductDtos)
            {
                var product = existingProducts.GetValueOrDefault(xmlProductDto.Id ?? 0);

                if (product != null)
                {
                    // Note: For current products keep the current price
                    xmlProductDto.MapCurrentEntity(product, keepPrice: true);
                } else
                {
                    var newProduct = xmlProductDto.MapNewEntity();
                    _context.Products.Add(newProduct);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse {Success = true};
        } catch (XmlException ex)
        {
            _errorMessage = "Invalid XML format.";
            _logger.LogError(ex, _errorMessage);
            return new BaseResponse(false, $"{_errorMessage}: {ex.Message}");
        } catch (DbUpdateException ex)
        {
            _errorMessage = "Database update error.";
            _logger.LogError(ex, _errorMessage);
            return new BaseResponse(false, $"{_errorMessage}: {ex.Message}");
        } catch (Exception ex)
        {
            _errorMessage = "An unexpected error occurred.";
            _logger.LogError(ex, _errorMessage);
            return new BaseResponse(false, $"{_errorMessage}: {ex.Message}");
        }
    }
}
