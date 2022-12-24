using AutoMapper;
using ECommerce.Application.Abstracts.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.src.Abstracts.Customer.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            this.CreateMap<CustomerRegisterInDto, Domain.Entities.Customer>();
        }
    }
}
