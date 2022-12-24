

using AutoMapper;
using ECommerce.Application.Abstracts.AuthGroupRole;
using ECommerce.Application.Abstracts.AuthGroup.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Core.Domain.AppUser;

namespace ECommerce.Application.Services.AuthGroup
{
    public class AuthGroupService : IAuthGroupService
    {
        private readonly IRepository<Core.Domain.AppUser.AuthGroup> _authGroupRepository;
        private readonly IMapper _mapper;
        public AuthGroupService(IRepository<Core.Domain.AppUser.AuthGroup> authGroupRepository, IMapper mapper)
        {
            _authGroupRepository = authGroupRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddWithRolesAsync(AuthGroupWithRoleAddInDto request)
        {
            var obj = new Core.Domain.AppUser.AuthGroup
            {
                Name = request.Name,
                AuthGroupRoles = request.RoleIds.Select(id => new AuthGroupRole { RoleId = id }).ToList(),
            }; 

            await _authGroupRepository.AddAsync(obj).ConfigureAwait(false);

            return new SuccessResult();
        }
 
        public async Task<IResult> DeleteAsync(int id)
        {
            await _authGroupRepository.DeleteAsync(new Core.Domain.AppUser.AuthGroup { Id = id }).ConfigureAwait(false);
            return new SuccessResult();
        }

        public async Task<IDataResult<AuthGroupWithRoleGetByIdOutDto>> GetByIdWithRolesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AuthGroupWithRoleListOutDto>> GetListWithRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(AuthGroupWithRoleUpdateInDto request)
        {
            throw new NotImplementedException();
        }
    }
}
