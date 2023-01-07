using ECommerce.Application.Abstracts.Roles;
using ECommerce.Application.Abstracts.Roles.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class RolesController : BaseController
    {

        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }



        [HttpPost("getRoleListByPaging")]
        public async Task<IActionResult> GetRoleListByPagingAsync(RolePagedListAdminInDto request)
        {
            var response = await _roleService.GetRoleListByPagingAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getRoleListByAuthGroupId")]
        public async Task<IActionResult> GetRolesByAuthGroupIdAsync(int authGroupId)
        {
            var response = await _roleService.GetRolesByAuthGroupIdAsync(authGroupId).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }


    }
}
