using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.CoreApplication.RequestParams
{
    public class PageRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
