using ECommerce.Application.Abstracts.AttributeGroup;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class AttributeGroupsController : BaseController
    {
        private readonly IAttributeGroupService _attributeGroupService;
        public AttributeGroupsController(IAttributeGroupService attributeGroupService)
        {
            _attributeGroupService = attributeGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AttributeGroupAddInDto request)
        {
            var response = await _attributeGroupService.AddAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] AttributeGroupUpdateInDto request)
        {
            var response = await _attributeGroupService.UpdateAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await _attributeGroupService.GetListAsync().ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _attributeGroupService.GetByIdAsync(id).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _attributeGroupService.DeleteAsync(id).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }
    }
}
