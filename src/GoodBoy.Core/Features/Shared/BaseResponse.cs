using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBoy.Core.Features.Shared;

public record BaseResponse(bool Success = true, string? Message = null)
{
    public bool Success { get; set; } = Success;
    public string? Message { get; set; } = Message;
}