using ECommerce.Core.Domain.AppUser;


namespace ECommerce.Application.Abstracts.CustomerAuth.JwtToken
{
    public interface ITokenCustomerHelper
    {
        Core.Utilities.Security.AccessToken CreateToken(Domain.Entities.Customer customer);
    }
}
