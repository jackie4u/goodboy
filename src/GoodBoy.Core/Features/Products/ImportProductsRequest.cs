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

    //public XmlDocument XmlDocument { get; set; } = new XmlDocument();
    public string XmlContent { get; set; } = ""; // Use string for XML content

    public record Response(bool Success, string? Message);
}