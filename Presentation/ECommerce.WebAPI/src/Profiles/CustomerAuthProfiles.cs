using AutoMapper;
using ECommerce.Application.Abstracts.Customer.Dtos;
using ECommerce.WebAPI.ViewModels.Customer;

namespace ECommerce.WebAPI.Profiles
{
    public class CustomerAuthProfiles:Profile
    {
        public CustomerAuthProfiles()
        {
            this.CreateMap<CustomerRegisterInVM, CustomerRegisterInDto>().ReverseMap();
        }
    }
}
