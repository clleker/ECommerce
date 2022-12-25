

using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.PagedList;

namespace ECommerce.Application.Abstracts.ProductCard
{
    public interface IProductCardService:IApplicationService
    {
        Task<IResult> AddAsync(ProductCardAddInDto request);
        Task<IDataResult<IPagedList<ProductListAdminOutDto>>> GetListProductByPagingAsync(ProductPagedListAdminInDto request);


    }
}
