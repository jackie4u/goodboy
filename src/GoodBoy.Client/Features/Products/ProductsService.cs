using GoodBoy.Core.Features.Products.Requests;
using System.Net.Http.Json;

namespace GoodBoy.Client.Features.Products;

public interface IProductsService
{
    Task<GetProductsRequest.Response> GetProductsAsync(CancellationToken cancellationToken);
}

public class ProductsService : IProductsService
{
    private readonly HttpClient _httpClient;

    public ProductsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetProductsRequest.Response> GetProductsAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetFromJsonAsync<GetProductsRequest.Response>(GetProductsRequest.RouteTemplate, cancellationToken);
        return response!;
    }
}