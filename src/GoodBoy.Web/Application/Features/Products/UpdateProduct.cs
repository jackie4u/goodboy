using FastEndpoints;
using GoodBoy.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GoodBoy.Web.Application.Features.Products;

[HttpPut("/product")]
[AllowAnonymous]
public class UpdateProduct
{
    //Todo <medium>: Reimplement
    //if (_offerings.TryGetValue(newProduct.Id, out Product oldProduct))
    //{
    //    // Key found, return the Product
    //    // return Result.Ok(newProduct);
    //} else
    //{
    //    // Key not found
    //    // return Result.Fail<Product, string>($"No newProduct found with ID: {id}");
    //}

    //_offerings[newProduct.Id] = newProduct;
    //return newProduct;
}
