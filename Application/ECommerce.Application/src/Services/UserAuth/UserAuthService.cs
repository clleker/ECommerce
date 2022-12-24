using AutoMapper;
using Core.Utilities.Security.Hashing;
using ECommerce.Application.Abstracts.Auth;
using ECommerce.Application.Abstracts.Auth.Dtos;
using ECommerce.Application.Abstracts.User;
using ECommerce.Application.Abstracts.User.Dtos;
using ECommerce.Application.Abstracts.UserAuth.JwtToken;
using ECommerce.Application.Constants;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Domain.AppUser;
using ECommerce.Core.Utilities.Security;

namespace ECommerce.Application.Services.UserAuth
{
    public class UserAuthService : IUserAuthService
    {
        public IUserService _userService { get; set; }
        public ITokenUserHelper _tokenHelper { get; set; }

        public IMapper _mapper;
        public UserAuthService(IUserService userService, ITokenUserHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
        public async Task<IDataResult<UserForLoginOutDto>> LoginAsync(UserForLoginInDto userForLoginDto)
        {
            var user = await _userService.GetByMailAsync(userForLoginDto.Email).ConfigureAwait(false);

            if (user == null)
            {
                return new ErrorDataResult<UserForLoginOutDto>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<UserForLoginOutDto>(Messages.PasswordError);
            }

            var result = _mapper.Map<UserForLoginOutDto>(user);

            return new SuccessDataResult<UserForLoginOutDto>(result, Messages.SuccessfulLogin);
        }

        public async Task<IDataResult<UserForRegisterOutDto>> RegisterAsync(UserForRegisterInDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new UserAddInDto
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var userOutDto = await _userService.AddAsync(user).ConfigureAwait(false);

            var result = _mapper.Map<UserForRegisterOutDto>(userOutDto.Data);


            return new SuccessDataResult<UserForRegisterOutDto>(result, Messages.SuccessfulRegistered);

        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            var user = await _userService.GetByMailAsync(email).ConfigureAwait(false);

            if (user != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user)
        {
            var roles = await _userService.GetRolesByUserIdAsync(user.Id).ConfigureAwait(false);
            var accessToken = _tokenHelper.CreateToken(user, roles.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


    }
}
