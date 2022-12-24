

using AutoMapper;
using Core.Utilities.Security.Hashing;
using ECommerce.Application.Abstracts.Customer;
using ECommerce.Application.Abstracts.Customer.Dtos;
using ECommerce.Application.Abstracts.CustomerAuth;
using ECommerce.Application.Abstracts.CustomerAuth.Dtos;
using ECommerce.Application.Abstracts.MailQuene;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Infrastructure.MessageBrokers;
using Newtonsoft.Json;

namespace ECommerce.Application.Services.CustomerAuth;
public class CustomerAuthService : ICustomerAuthService
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IMessageBrokerHelper _messageBrokerHelper;

    public CustomerAuthService(ICustomerService customerService, IMapper mapper, IMessageBrokerHelper messageBrokerHelper)
    {
        _customerService = customerService;
        _mapper = mapper;
        _messageBrokerHelper = messageBrokerHelper;
    }


    public async Task<IDataResult<CustomerRegisterOutDto>> RegisterAsync(CustomerRegisterInDto request)
    {
        var dbCustomer = await _customerService.GetByEmailAsync(request.Email).ConfigureAwait(false);
        var result = new CustomerRegisterOutDto { RemainingTime = 300, MailControlStatus = true, Message = "300 saniye içerisinde veriyi gir" };
        if (dbCustomer == null)
        {
            #region AddCustomer
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var customer = new CustomerAddInDto
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                RegisterDate = DateTime.UtcNow,
            };

            await _customerService.AddAsync(customer);
            #endregion

            SendMail(request);
            return new SuccessDataResult<CustomerRegisterOutDto>();
        }
        else if (dbCustomer != null && dbCustomer.IsConfirmEmail == false)
        {
            var operationTime = dbCustomer.RegisterDate.AddMinutes(5);

            if (DateTime.UtcNow >= operationTime)
            {
                SendMail(request);
            }
            else
            {
                result.RemainingTime = (operationTime - dbCustomer.RegisterDate).TotalSeconds;
            }
        }
        
        return new SuccessDataResult<CustomerRegisterOutDto>(result);
    }

    public async Task<Domain.Entities.Customer> CustomerExistsAsync(string email)
    {
        return await _customerService.GetByEmailAsync(email).ConfigureAwait(false);
    }

    /// <summary>
    /// SendtoRabbitMq
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private void SendMail(CustomerRegisterInDto request)
    {
        int confirmedNumber = new Random().Next(1000, 9999);

        var sendedMailDto = new SendedMailDto
        {
            Body = confirmedNumber.ToString(),
            Subject = "Yeni Kullanıcı",
            ToEmail = request.Email,
            ToFullName = $"{request.FirstName} {request.LastName}"
        };

        _messageBrokerHelper.QueueMessage(JsonConvert.SerializeObject(sendedMailDto));
    }


}
