using AutoMapper;
using ECommerce.Application.Abstracts.Customer.Dtos;


namespace ECommerce.Application.Abstracts.CustomerAuth.Profiles
{
    public class CustomerAuthProfiles : Profile
    {
        public CustomerAuthProfiles()
        {
            this.CreateMap<CustomerAddInDto, Domain.Entities.Customer>();
       
        }
    }
}
