

using ECommerce.Application.Abstracts.ProductCardAttribute.Dtos;
using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.ProductCardAttribute
{
        public interface IProductCardAttributeService : IApplicationService
        {
            Task<IDataResult<ProductCardAttributeOutDto>> GetWithParentsbyId(int productCardAttributeId);
    }
}
