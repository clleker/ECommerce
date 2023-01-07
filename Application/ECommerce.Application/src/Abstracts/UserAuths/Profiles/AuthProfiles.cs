using AutoMapper;
using ECommerce.Application.Abstracts.Auth.Dtos;
using ECommerce.Application.Abstracts.User.Dtos;
using ECommerce.Core.Domain.AppUser;

namespace ECommerce.Application.Abstracts.Auth.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            this.CreateMap<AppUser, UserForLoginOutDto>().ReverseMap();
            this.CreateMap<UserForLoginInDto, AppUser>();
            this.CreateMap<UserForLoginOutDto, UserForRegisterOutDto>();
            this.CreateMap<UserAddOutDto, UserForRegisterOutDto>();
            this.CreateMap<UserForRegisterOutDto, AppUser>();
        }
    }
}
