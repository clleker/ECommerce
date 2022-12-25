using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Application.Abstracts.ProductCard.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    public class ProductCardController : Controller
    {
        private readonly IProductCardService _productCardService;

        public IActionResult Index()
        {
            return View();
        }

    }


}
