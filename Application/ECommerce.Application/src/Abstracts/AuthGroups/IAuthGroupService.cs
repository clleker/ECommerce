using ECommerce.Application.Abstracts.AuthGroup.Dtos;
using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.AuthGroupRole
{
    public interface IAuthGroupService: IApplicationService
    {
        Task<IResult> AddWithRolesAsync(AuthGroupWithRoleAddInDto request);
        Task<IResult> UpdateWithRolesAsync(AuthGroupWithRoleUpdateInDto request);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<List<AuthGroupListOutDto>>> GetListAsync();
    }
}
