using ECommerce.Application.Abstracts.Auth.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Domain.AppUser;

namespace ECommerce.Application.Abstracts.Auth
{
    public interface IUserAuthService : IApplicationService
    {
        Task<IDataResult<UserForLoginOutDto>> LoginAsync(UserForLoginInDto userForLoginDto);
        Task<IDataResult<UserForRegisterOutDto>> RegisterAsync(UserForRegisterInDto userForRegisterDto, string password);
        Task<IDataResult<Core.Utilities.Security.AccessToken>> CreateAccessToken(AppUser user);
        Task<IResult> UserExistsAsync(string email);
    }
}
