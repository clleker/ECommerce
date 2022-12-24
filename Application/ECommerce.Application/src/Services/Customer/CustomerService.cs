using AutoMapper;
using ECommerce.Application.Abstracts.Customer;
using ECommerce.Application.Abstracts.Customer.Dtos;
using ECommerce.Application.Abstracts.MailQuene;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;
public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(IRepository<Customer> customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(CustomerAddInDto request)
    {
        var customer = _mapper.Map<Customer>(request);
        await _customerRepository.AddAsync(customer).ConfigureAwait(false);

        return new SuccessResult();
    }

    public async Task<Customer> GetByEmailAsync(string email)
    {
        return await _customerRepository.GetFirstOrDefaultAsync(predicate: x => x.Email == email).ConfigureAwait(false);
    }
}
