using AutoMapper;
using ECommerce.Application.Abstracts.Category;
using ECommerce.WebAPI.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMobileMenu()
        {
            var response = await _categoryService.GetListWithChildrenAsync().ConfigureAwait(false);

            if (response.Success)
            {
                return this.BadRequest(response);
            }

            var result = _mapper.Map<MobileMenu>(response);

            return Ok(result);
        }
    }
}
