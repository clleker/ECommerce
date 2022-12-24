using ECommerce.Core.Domain.AppUser;


namespace ECommerce.Application.Abstracts.UserAuth.JwtToken
{
    public interface ITokenUserHelper
    {
        Core.Utilities.Security.AccessToken CreateToken(AppUser user, List<AppRole> roles);
    }
}
