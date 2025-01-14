using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GoodBoy.Core.Features.Products;
public class ImportProductsRequest
{
    public const string RouteTemplate = "/products/import";

    public string XmlContent { get; set; } = ""; // Use string for XML content instead of XmlDocument

    public record Response(bool Success, string? Message);
}