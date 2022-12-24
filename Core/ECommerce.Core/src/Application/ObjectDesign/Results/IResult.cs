using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Application.ObjectDesign
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
