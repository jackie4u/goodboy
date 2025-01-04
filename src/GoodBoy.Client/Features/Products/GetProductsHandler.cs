using GoodBoy.Core.Features.Products.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GoodBoy.Client.Features.Products;

public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsRequest.Response>
{
    private readonly HttpClient _httpClient;

    public GetProductsHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetProductsRequest.Response> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetFromJsonAsync<GetProductsRequest.Response>(GetProductsRequest.RouteTemplate, cancellationToken);
        return response!;
    }
}