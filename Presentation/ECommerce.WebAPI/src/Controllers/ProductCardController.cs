using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    public class ProductCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
