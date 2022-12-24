using AutoMapper;
using ECommerce.Application.Abstracts.Customer;

namespace ECommerce.WebAPI.Controllers
{
    public class CustomerController : BaseController
    {
        public readonly ICustomerService _customerService;
        public readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        //public async Task<IActionResult> Register(CustomerRegisterInVM customer)
        //{
        //    var entity = _mapper.Map<CustomerRegisterInDto>(customer);
        //   await _customerAuthService.RegisterAsync(entity).ConfigureAwait(false);

        //    return Ok();
        //}

    }
}
