using AutoMapper;
using ECommerce.Application.Abstracts.Customer.Dtos;
using ECommerce.Application.Abstracts.CustomerAuth;
using ECommerce.Application.Abstracts.CustomerAuth.JwtToken;
using ECommerce.WebAPI.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    public class CustomerAuthController : BaseController
    {
        private ICustomerAuthService _customerAuthService;

        private readonly ITokenCustomerHelper _jwtHelper;
        private readonly IMapper _mapper;
        public CustomerAuthController(ICustomerAuthService customerAuthService, ITokenCustomerHelper jwtHelper, IMapper mapper)
        {
            _customerAuthService = customerAuthService;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerRegisterInVM customer)
        {
            var entity = _mapper.Map<CustomerRegisterInDto>(customer);
            await _customerAuthService.RegisterAsync(entity).ConfigureAwait(false);

            return Ok();
        }
    }
}
