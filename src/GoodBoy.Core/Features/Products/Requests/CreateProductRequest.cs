using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GoodBoy.Core.Features.Products.Requests;

public class CreateProductRequest : IRequest<CreateProductRequest.Response>
{
    public ProductDto Product { get; set; } = new ProductDto(); // Initialize Product

    public record Response(int? ProductId);
}

