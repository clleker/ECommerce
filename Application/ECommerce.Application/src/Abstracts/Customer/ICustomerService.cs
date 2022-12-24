using ECommerce.Application.Abstracts.Customer.Dtos;
using ECommerce.Core.Application.ObjectDesign;


namespace ECommerce.Application.Abstracts.Customer
{
    public interface ICustomerService:IApplicationService
    {
        Task<IResult> AddAsync(CustomerAddInDto request);
        Task<Domain.Entities.Customer> GetByEmailAsync(string email);
    }
}
