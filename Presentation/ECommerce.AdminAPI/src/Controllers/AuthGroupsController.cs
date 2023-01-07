using ECommerce.Application.Abstracts.AuthGroup.Dtos;
using ECommerce.Application.Abstracts.AuthGroupRole;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class AuthGroupsController : BaseController
    {
        private readonly IAuthGroupService _authGroupRoleService;

        public AuthGroupsController(IAuthGroupService authGroupRoleService)
        {
            _authGroupRoleService = authGroupRoleService;
        } 

        [HttpPost("addWithRoles")]
        public async Task<IActionResult> Add([FromBody] AuthGroupWithRoleAddInDto request)
        {
            var response = await _authGroupRoleService.AddWithRolesAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetListAsync()
        {
            var response = await _authGroupRoleService.GetListAsync().ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("updateWithRoles")]
        public async Task<IActionResult> Update([FromBody] AuthGroupWithRoleUpdateInDto request)
        {
            var response = await _authGroupRoleService.UpdateWithRolesAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }
    }
}
