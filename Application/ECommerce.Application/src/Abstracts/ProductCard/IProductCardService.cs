

using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.ProductCard
{
    public interface IProductCardService:IApplicationService
    {
        Task<IResult> AddAsync(ProductCardAddInDto request);
    }
}
