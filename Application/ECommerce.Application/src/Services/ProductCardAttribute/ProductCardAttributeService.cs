
using ECommerce.Application.Abstracts.ProductCardAttribute;
using ECommerce.Application.Abstracts.ProductCardAttribute.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services
{
    public class ProductCardAttributeService : IProductCardAttributeService
    {
        private readonly IRepository<ProductCardAttribute> _productCardAttributeRepository;
        public ProductCardAttributeService(IRepository<ProductCardAttribute> productCardAttributeRepository)
        {
            _productCardAttributeRepository = productCardAttributeRepository;
        }

        public async Task<IDataResult<ProductCardAttributeOutDto>> GetWithParentsbyId(int productCardAttributeId)
        {
            var result = await _productCardAttributeRepository.GetFirstOrDefaultAsync(
                selector: x => new ProductCardAttributeOutDto
                {
                    Id = x.Id,
                    AttributeName = x.Attribute.Name,
                    ParentList = x.SubProductCardAttributes.Select(y => new ProductCardAttributeSubOutDto
                    {
                        Id = y.Id,
                        AttributeId = y.Attribute.Id,
                        AttributeName = y.Attribute.Name
                    }).ToList()
                },
                predicate: x => x.Id == productCardAttributeId,
                include: x => x.Include(x => x.SubProductCardAttributes)
                               .ThenInclude(x => x.Attribute)
                               .Include(x => x.Attribute));

            return new DataResult<ProductCardAttributeOutDto>(result, true);
        }
    }
}
