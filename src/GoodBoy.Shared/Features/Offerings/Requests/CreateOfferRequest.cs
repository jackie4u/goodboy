using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBoy.Shared.Features.Offerings.Requests;

public class CreateOfferRequest
{
    // public required int Id { get; set; }
    // public string Ean { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Quantity { get; set; } = 0;
    public decimal Price { get; set; } = decimal.Zero;
    // public string Currency {  get; set; }
    // public List<Category> Categories {  get; set; }
}
