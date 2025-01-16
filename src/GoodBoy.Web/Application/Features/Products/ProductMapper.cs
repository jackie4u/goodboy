using GoodBoy.Core.Enums;
using System.Globalization;
using System.Xml;
using GoodBoy.Core.Features.Products;
using GoodBoy.Web.Data.Entities;

namespace GoodBoy.Web.Application.Features.Products;

public static class ProductMapper
{
    public static Product MapNewEntity(this ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Ean = productDto.Ean,
            Name = productDto.Name,
            Description = productDto.Description,
            Quantity = productDto.Quantity,
            Currency = productDto.Currency,
            Price = productDto.Price,
            Categories = productDto.Categories,
            MainPicture = productDto.MainPicture,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow
        };
    }

    public static void MapCurrentEntity(this ProductDto productDto, Product product, bool keepPrice = false)
    {
        product.Id = productDto.Id ?? product.ProductId;
        product.Ean = productDto.Ean;
        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Quantity = productDto.Quantity;
        product.Currency = productDto.Currency;
        product.UpdatedOn = (product.Price != productDto.Price ? DateTime.UtcNow : product.UpdatedOn);
        product.Price = (keepPrice ? product.Price : productDto.Price);
        product.Categories = productDto.Categories;
        product.MainPicture = productDto.MainPicture;
    }

    public static ProductDto MapFromXmlNode(XmlNode productNode)
    {
        return new ProductDto
        {
            Id = int.Parse(productNode["id"]?.InnerText ?? "0"),
            Ean = productNode["ean"]?.InnerText,
            Name = productNode["name"]?.InnerText ?? string.Empty,
            Description = productNode["description"]?.InnerText,
            Quantity = int.Parse(productNode["quantity"]?.InnerText ?? "0"),
            Price = decimal.Parse(productNode["price"]?.InnerText ?? "0", CultureInfo.InvariantCulture),
            Currency = Enum.Parse<Currencies>(productNode["currency"]?.InnerText ?? "CZK"),
            Categories = productNode["categories"]?.InnerText,
            MainPicture = productNode["mainPicture"]?.InnerText
        };
    }
}
