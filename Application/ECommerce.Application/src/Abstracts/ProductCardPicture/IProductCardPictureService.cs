

using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.ProductCard
{
    public interface IProductCardPictureService : IApplicationService
    {
        Task<IResult> AddPicturesToProduct(ProductCardPictureAddInDto request);

        /// <summary>
        /// GetProductCardPicturesByProductCardId
        /// </summary>
        /// <param name="productCardId"></param>
        /// <returns></returns>
        Task<IDataResult<List<ProductCardPictureListOutDto>>> GetListByProductCardId(int productCardId);

    }
}
