using FastEndpoints;
using GoodBoy.Core.Features.Products;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPost(ImportProductsRequest.RouteTemplate)]
[AllowAnonymous]
public class ImportProducts : Endpoint<ImportProductsRequest, ImportProductsRequest.Response>
{
    private readonly IImportProductsService _importService;

    public ImportProducts(IImportProductsService importService)
    {
        _importService = importService;
    }

    public override async Task HandleAsync(ImportProductsRequest req, CancellationToken cancellationToken)
    {
        var (success, message) = await _importService.ImportProductsAsync(req.XmlContent, cancellationToken);
        await SendAsync(new ImportProductsRequest.Response(success, message), cancellation: cancellationToken);
    }
}