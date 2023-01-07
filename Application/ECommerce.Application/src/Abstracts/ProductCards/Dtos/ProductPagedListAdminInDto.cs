using ECommerce.Core.Common.Paging;

namespace ECommerce.Application.Abstracts.ProductCard.Dtos
{
    public class ProductPagedListAdminInDto: PagingRequestInDto
    {
        public string ProductName { get; set; }
    }
}
