

using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Common.Paging
{
    public class PagingRequestInDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedRequestDto"/> class.
        /// </summary>
        public PagingRequestInDto()
        {
            Orders = new List<PagedRequestOrderSubDto>();
        }

        public List<PagedRequestOrderSubDto> Orders { get; set; }

        [Range(0, int.MaxValue)]
        public int PageIndex { get; set; }

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        public string Search { get; set; }
    }
    public class PagedRequestOrderSubDto
    {
        public string ColumnName { get; set; }

        public bool DirectionDesc { get; set; }
    }
}
