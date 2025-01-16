using FastEndpoints;
using GoodBoy.Client.Features.Shared;
using GoodBoy.Core.Features.Products;
using GoodBoy.Core.Features.Shared;
using GoodBoy.Web.Data.Entities;
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
        var serviceResponse = await _importService.ImportProductsAsync(req.XmlContent, cancellationToken);
        var response = new ImportProductsRequest.Response(serviceResponse.Success, serviceResponse.Message);
        await SendAsync(response, cancellation: cancellationToken);
    }
}