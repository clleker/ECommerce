using ECommerce.Core.Domain.AppUser;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Application.Abstracts.User.Dtos;

namespace ECommerce.Application.Abstracts.User
{
    public interface IUserService:IApplicationService
    {
        Task<AppUser> GetByMailAsync(string mail);
        Task<IDataResult<UserAddOutDto>> AddAsync(UserAddInDto user);
        Task<IDataResult<List<AppRole>>> GetRolesByUserIdAsync(int userId);
    }
}
