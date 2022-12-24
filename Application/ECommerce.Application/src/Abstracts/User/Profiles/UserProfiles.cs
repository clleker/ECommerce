using AutoMapper;
using ECommerce.Application.Abstracts.Auth.Dtos;
using ECommerce.Application.Abstracts.User.Dtos;
using ECommerce.Core.Domain.AppUser;

namespace ECommerce.Application.Abstracts.Auth.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            this.CreateMap<UserForLoginInDto, AppUser>();
            this.CreateMap<AppUser, UserForLoginOutDto>();
            this.CreateMap<UserAddInDto, AppUser>();
            this.CreateMap<UserAddOutDto, AppUser>().ReverseMap();
        }
    }
}
