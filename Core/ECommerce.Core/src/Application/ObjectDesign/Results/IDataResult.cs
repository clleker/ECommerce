using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Application.ObjectDesign
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
