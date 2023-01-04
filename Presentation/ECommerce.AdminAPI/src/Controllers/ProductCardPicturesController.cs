using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Application.Abstracts.ProductCard.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    public class ProductCardPicturesController : BaseController
    {

        private readonly IProductCardPictureService _productCardPictureService;

        public ProductCardPicturesController(IProductCardPictureService productCardPictureService)
        {
            _productCardPictureService = productCardPictureService;
        }


        [HttpPost("addPicturesToProduct")]
        public async Task<IActionResult> AddProductCardPictures([FromForm] ProductCardPictureAddInDto request)
        {
            var response = await _productCardPictureService.AddPicturesToProduct(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }


        [HttpGet("getPicturesByProductCardId")]
        public async Task<IActionResult> Add(int productCardId)
        {
            var response = await _productCardPictureService.GetListByProductCardId(productCardId).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

    }
}
