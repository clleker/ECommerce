using AutoMapper;
using ECommerce.Application.Abstracts.AuthGroup.Dtos;

namespace ECommerce.Application.Abstracts.AuthGroupRoles.Profiles
{
    public class AuthGroupRoleProfiles : Profile
    {
        public AuthGroupRoleProfiles()
        {
            this.CreateMap<AuthGroupWithRoleAddInDto, Core.Domain.AppUser.AuthGroup>();
             



            //this.CreateMap<AuthGroupWithRoleUpdateInDto, Core.Domain.AppUser.AuthGroupRole>();
            //this.CreateMap<Core.Domain.AppUser.AuthGroupRole, AuthGroupRoleListOutDto>();
            //this.CreateMap<AuthGroupRoleUpdateInDto, Core.Domain.AppUser.AuthGroupRole>();

        }
    }
}
