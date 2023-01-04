using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Application.Abstracts.ProductCard.Dtos;
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

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductCardAddInDto request)
        {
            var response = await _productCardService.AddAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        } 

        //[HttpPost]
        //public async Task<IActionResult> GetListProductByPaging(ProductPagedListAdminInDto request)
        //{
        //    var response = await _productCardService.GetListProductByPagingAsync(request).ConfigureAwait(false);

        //    if (!response.Success)
        //    {
        //        return this.BadRequest(response);
        //    }

        //    return Ok(response);
        //}

        [HttpPost("getExtendedProductCardList")]
        public async Task<IActionResult> GetListProductByPaging(ProductPagedListAdminInDto request)
        {
            var response = await _productCardService.GetExtendedProductCardListByPagingAsync(request).ConfigureAwait(false);

            if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return Ok(response);
        }

  

    }
}
