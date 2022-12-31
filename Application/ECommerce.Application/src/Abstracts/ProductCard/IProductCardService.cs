

using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.PagedList;

namespace ECommerce.Application.Abstracts.ProductCard
{
    public interface IProductCardService : IApplicationService
    {
        Task<IResult> AddAsync(ProductCardAddInDto request);

        /// <summary>
        /// Her bir product nesnesini döndürür.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //Task<IDataResult<IPagedList<ProductListAdminOutDto>>> GetListProductByPagingAsync(ProductPagedListAdminInDto request);

        Task<IDataResult<IPagedList<ProductExtendedListAdminOutDto>>> GetExtendedProductCardListByPagingAsync(ProductPagedListAdminInDto request);
        Task<IResult> AddPicturesToProduct(ProductPictureAddInDto request);

    }
}
