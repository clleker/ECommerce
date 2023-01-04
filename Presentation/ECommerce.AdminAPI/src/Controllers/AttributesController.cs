using ECommerce.Application.Abstracts.Attribute;
using ECommerce.Application.Abstracts.ProductCardAttribute;
using ECommerce.Common.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class AttributesController : BaseController
    {
        private readonly IAttributeService _attributeService;
        private readonly IProductCardAttributeService _test;

        public AttributesController(IAttributeService attributeService, IProductCardAttributeService test)
        {
            _attributeService = attributeService;
            _test = test;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test(int id)
        {
            var response = await _test.GetWithParentsbyId(id).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        //[Authorize(Roles = ECommercePermissionPolicy.Attribute_Add)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AttributeAddInDto request)
        {
            var response = await _attributeService.AddAsync(request).ConfigureAwait(false);
            
            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] AttributeUpdateInDto request)
        {
            var response = await _attributeService.UpdateAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var response = await _attributeService.GetListAsync().ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _attributeService.GetByIdAsync(id).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _attributeService.DeleteAsync(id).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }
    }
}
