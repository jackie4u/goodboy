using GoodBoy.Client.Features.Products;
using GoodBoy.Web.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

// Goodboy app specific services
//builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
