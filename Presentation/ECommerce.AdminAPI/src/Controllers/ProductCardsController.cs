using ECommerce.Application.Abstracts.ProductCard;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class ProductCardsController : BaseController
    {

        private readonly IProductCardService _productCardService;

        public ProductCardsController(IProductCardService productCardService)
        {
            _productCardService = productCardService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductCardAddInDto request)
        {
            var response = await _productCardService.AddAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

    }
}
