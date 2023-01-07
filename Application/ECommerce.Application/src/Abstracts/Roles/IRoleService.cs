

using ECommerce.Application.Abstracts.AuthGroup.Dtos;
using ECommerce.Application.Abstracts.Roles.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.PagedList;

namespace ECommerce.Application.Abstracts.Roles
{
    public interface IRoleService : IApplicationService
    {
        Task<IDataResult<IPagedList<RoleListAdminOutDto>>> GetRoleListByPagingAsync(RolePagedListAdminInDto request);

        Task<IDataResult<List<RoleListByAuthGroupIdOutDto>>> GetRolesByAuthGroupIdAsync(int authGroupId);

    }
}
