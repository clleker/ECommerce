using AutoMapper;
using ECommerce.Application.Abstracts.Roles;
using ECommerce.Application.Abstracts.Roles.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Domain.AppUser;
using ECommerce.Core.Persistance.PagedList;
using ECommerce.Core.Persistance.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IRepository<AuthGroupRole> _authGroupRoleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRepository<AppRole> roleRepository,
            IMapper mapper,
            IRepository<AuthGroupRole> authGroupRoleRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _authGroupRoleRepository = authGroupRoleRepository;
        }

        public async Task<IDataResult<IPagedList<RoleListAdminOutDto>>> GetRoleListByPagingAsync(RolePagedListAdminInDto request)
        {
            var result = await _roleRepository.GetPagedListAsync(
                          selector: x => new RoleListAdminOutDto
                          {
                              Id = x.Id,
                              DisplayName = x.DisplayName,
                              Name = x.Name,
                          },
                          predicate: x => string.IsNullOrEmpty(request.DisplayName) || EF.Functions.Like(EF.Functions.Collate(x.DisplayName, "Latin1_general_CI_AI"), $"%{request.DisplayName}%"),
                          pageIndex : request.PageIndex,
                          pageSize : request.PageSize
                          );

            return new DataResult<IPagedList<RoleListAdminOutDto>>(result,true);
        }


        public async Task<IDataResult<List<RoleListByAuthGroupIdOutDto>>> GetRolesByAuthGroupIdAsync(int authGroupId)
        {
            var result = await _authGroupRoleRepository.GetListAsync(
               selector: x => new RoleListByAuthGroupIdOutDto
               {
                       RoleId = x.Role.Id,
                       RoleDisplayName = x.Role.DisplayName,
               },
               predicate: x => x.AuthGroupId == authGroupId,
               include: x => x.Include(x => x.Role)
               );

            return new SuccessDataResult<List<RoleListByAuthGroupIdOutDto>>(result);
        }
    }
}
