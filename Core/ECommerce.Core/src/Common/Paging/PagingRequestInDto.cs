

using ECommerce.Core.src.Common.Paging;

namespace ECommerce.Core.Common.Paging
{
    public class PagingRequestInDto : BasePagingRequestInDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedRequestDto"/> class.
        /// </summary>
        public PagingRequestInDto()
        {
            Orders = new List<PagedRequestOrderSubDto>();
        }

        public List<PagedRequestOrderSubDto> Orders { get; set; }
    }

    public class PagedRequestOrderSubDto
    {
        public string ColumnName { get; set; }

        public bool DirectionDesc { get; set; }
    }
}
