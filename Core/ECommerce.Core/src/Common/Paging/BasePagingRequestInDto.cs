
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Core.src.Common.Paging
{
    public class BasePagingRequestInDto
    {
        [Range(0, int.MaxValue)]
        public int PageIndex { get; set; }

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        public string Search { get; set; }
    }
}
