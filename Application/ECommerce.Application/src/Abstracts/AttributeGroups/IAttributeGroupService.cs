

using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.AttributeGroup
{
    public interface IAttributeGroupService : IApplicationService
    {
        Task<IResult> AddAsync(AttributeGroupAddInDto request);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(AttributeGroupUpdateInDto request);
        Task<IDataResult<AttributeGroupGetByIdOutDto>> GetByIdAsync(int id);
        Task<IDataResult<List<AttributeGroupListOutDto>>> GetListAsync();
    }
}
