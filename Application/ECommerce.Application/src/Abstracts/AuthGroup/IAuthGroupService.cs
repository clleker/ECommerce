using ECommerce.Application.Abstracts.AuthGroup.Dtos;
using ECommerce.Core.Application.ObjectDesign;

namespace ECommerce.Application.Abstracts.AuthGroupRole
{
    public interface IAuthGroupService: IApplicationService
    {
        Task<IResult> AddWithRolesAsync(AuthGroupWithRoleAddInDto request);
        Task<IResult> UpdateAsync(AuthGroupWithRoleUpdateInDto request);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<AuthGroupWithRoleListOutDto>> GetListWithRolesAsync();
        Task<IDataResult<AuthGroupWithRoleGetByIdOutDto>> GetByIdWithRolesAsync(int id);
    }
}
