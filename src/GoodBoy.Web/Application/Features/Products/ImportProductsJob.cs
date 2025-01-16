using GoodBoy.Core.Features.Products;
using System.Threading;
using Quartz;
using static FastEndpoints.Ep;

namespace GoodBoy.Web.Application.Features.Products;

public class ImportProductsJob : IJob 
{
    private readonly ILogger<ImportProductsJob> _logger;
    private readonly IImportProductsService _importService;

    public ImportProductsJob(ILogger<ImportProductsJob> logger, IImportProductsService importService)
    {
        _logger = logger;
        _importService = importService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            string productsXml = await File.ReadAllTextAsync("wwwroot/Products/products_feed.xml");

            var serviceResponse = await _importService.ImportProductsAsync(productsXml, context.CancellationToken);

            if (serviceResponse.Success)
            {
                _logger.LogInformation("Products imported successfully from file.");
            }
            else
            {
                _logger.LogError("Product import from file failed: {Message}", serviceResponse.Message);
            }
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, "Error reading product feed XML file.");
        }
    }
}