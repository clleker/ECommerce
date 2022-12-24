using AutoMapper;
using ECommerce.Application.Abstracts.User;
using ECommerce.Application.Abstracts.User.Dtos;
using ECommerce.Application.Constants;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Domain.AppUser;
using ECommerce.Core.Persistance.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserAddOutDto>> AddAsync(UserAddInDto request)
        {
            var user = _mapper.Map<AppUser>(request);

            await _userRepository.AddAsync(user).ConfigureAwait(false);

            var userMapped = _mapper.Map<UserAddOutDto>(user);

            return new SuccessDataResult<UserAddOutDto>(userMapped);
        }

        public async Task<AppUser> GetByMailAsync(string mail)
        {
           return await _userRepository.GetFirstOrDefaultAsync(predicate: x => x.Email == mail).ConfigureAwait(false);
        }

        public async Task<IDataResult<List<AppRole>>> GetRolesByUserIdAsync(int userId)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(
                predicate: (x => x.Id == userId),
                include: x => x.Include(x => x.UserAuthGroups)
                .ThenInclude(x => x.AuthGroup)
                .ThenInclude(x => x.AuthGroupRoles)
                .ThenInclude(x => x.Role)).ConfigureAwait(false);

            if (user == null)
            {
                return new ErrorDataResult<List<AppRole>>(Messages.UserNotFound);
            }

            //added user's roles
            List<AppRole> roles = new List<AppRole>();
            foreach (var item in user.UserAuthGroups)
            {
                var partOfRoles = item.AuthGroup.AuthGroupRoles.Select(y => y.Role).ToList();
                roles.AddRange(partOfRoles);
            }

            return new SuccessDataResult<List<AppRole>>(roles);
        }

        public async Task<IDataResult<AppUser>> GetRolesOfUserByEmailAndPassword(string mail, string password)
        {
            var result = await _userRepository.GetFirstOrDefaultAsync(predicate: x => x.Email == mail).ConfigureAwait(false);

            if (result == null)
            {
                return new ErrorDataResult<AppUser>(Messages.UserNotFound);
            }

            return new SuccessDataResult<AppUser>(result);
        }
    }
}

