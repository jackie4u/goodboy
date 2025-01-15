using Quartz;

namespace GoodBoy.Web.Application.Features.Products;

// ImportProductsJob.cs
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

            var (success, message) = await _importService.ImportProductsAsync(productsXml, context.CancellationToken);

            if (success)
            {
                _logger.LogInformation("Products imported successfully from file.");
            }
            else
            {
                _logger.LogError("Product import from file failed: {Message}", message);
            }
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, "Error reading product feed XML file.");
        }
    }
}