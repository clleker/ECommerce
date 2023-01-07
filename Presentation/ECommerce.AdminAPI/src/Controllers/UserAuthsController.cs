
using AutoMapper;
using ECommerce.Application.Abstracts.Auth;
using ECommerce.Application.Abstracts.Auth.Dtos;
using ECommerce.Core.Domain.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class UserAuthsController : BaseController
    {
        private IUserAuthService _authService;
        private IMapper _mapper;
        public UserAuthsController(IUserAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserForLoginInDto userForLoginDto)
        {
            var userToLogin = await _authService.LoginAsync(userForLoginDto).ConfigureAwait(false);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = await _authService.CreateAccessToken(_mapper.Map<AppUser>(userToLogin.Data)).ConfigureAwait(false);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegisterInDto userForRegisterDto)
        {
            var userExists = await _authService.UserExistsAsync(userForRegisterDto.Email).ConfigureAwait(false);

            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = await _authService.RegisterAsync(userForRegisterDto, userForRegisterDto.Password).ConfigureAwait(false);
            var result = await _authService.CreateAccessToken(_mapper.Map<AppUser>(registerResult.Data)).ConfigureAwait(false);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

    }
}
