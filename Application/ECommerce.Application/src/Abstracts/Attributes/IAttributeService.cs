
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstracts.Attribute
{
    public interface IAttributeService: IApplicationService
    {
        Task<IResult> AddAsync(AttributeAddInDto request);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(AttributeUpdateInDto request);
        Task<Attribute_> GetByNameAsync(string attributeName);
        Task<IDataResult<AttributeGetByIdOutDto>> GetByIdAsync(int id);
        Task<IDataResult<List<AttributeListOutDto>>> GetListAsync();
    }
}
