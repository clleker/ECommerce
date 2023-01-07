

using AutoMapper;
using ECommerce.Application.Abstracts.AuthGroupRole;
using ECommerce.Application.Abstracts.AuthGroup.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Core.Domain.AppUser;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services.AuthGroups
{
    public class AuthGroupService : IAuthGroupService
    {
        private readonly IRepository<AuthGroup> _authGroupRepository;
        private readonly IMapper _mapper;
        public AuthGroupService(IRepository<AuthGroup> authGroupRepository, IMapper mapper)
        {
            _authGroupRepository = authGroupRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddWithRolesAsync(AuthGroupWithRoleAddInDto request)
        {
            var obj = new AuthGroup
            {
                Name = request.Name,
                AuthGroupRoles = request.RoleIds.Select(id => new AuthGroupRole { RoleId = id }).ToList(),
            };

            await _authGroupRepository.AddAsync(obj).ConfigureAwait(false);

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _authGroupRepository.DeleteAsync(new AuthGroup { Id = id }).ConfigureAwait(false);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<AuthGroupListOutDto>>> GetListAsync()
        {
            var result = await _authGroupRepository.GetListAsync(
                 selector: x => new AuthGroupListOutDto { AuthGroupId = x.Id, Name = x.Name });

            return new SuccessDataResult<List<AuthGroupListOutDto>>(result);
        }

 

        public async Task<IResult> UpdateWithRolesAsync(AuthGroupWithRoleUpdateInDto request)
        {
            //Code will written by Celal
            throw new NotImplementedException();
        }

       
    }
}
