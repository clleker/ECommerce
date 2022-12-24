using ECommerce.Application.Abstracts.Customer.Dtos;
using ECommerce.Application.Abstracts.CustomerAuth.Dtos;
using ECommerce.Core.Application.ObjectDesign;


namespace ECommerce.Application.Abstracts.CustomerAuth
{
    public interface ICustomerAuthService: IApplicationService
    {
        Task<IDataResult<CustomerRegisterOutDto>> RegisterAsync(CustomerRegisterInDto request);

        Task<Domain.Entities.Customer> CustomerExistsAsync(string email);

        //Task<IDataResult<UserForLoginOutDto>> LoginAsync(UserForLoginInDto userForLoginDto);
        //Task<IDataResult<UserForRegisterOutDto>> RegisterAsync(UserForRegisterInDto userForRegisterDto, string password);
        //Task<IDataResult<Core.Utilities.Security.AccessToken>> CreateAccessToken(AppUser user);
    }
}
