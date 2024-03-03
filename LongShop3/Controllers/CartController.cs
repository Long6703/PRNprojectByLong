using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers
{
    public class CartController : Controller
    {
        [Route("/viewcart")]
        public IActionResult ViewCart()
        {
            return View("~/Views/Cart.cshtml");
        }
    }
}
