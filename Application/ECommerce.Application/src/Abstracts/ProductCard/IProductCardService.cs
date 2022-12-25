

using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.ProductCard
{
    public interface IProductCardService:IApplicationService
    {
        Task<IResult> AddAsync(ProductCardAddInDto request);
        Task<IDataResult<ProductListAdminOutDto>> GetListProductByPagingAsync(ProductPagedListAdminInDto request);


    }
}
