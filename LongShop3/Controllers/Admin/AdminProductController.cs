using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    public class AdminProductController : Controller
    {
        [Route("/manageproduct")]
        public IActionResult ManageProduct()
        {
            
            return View("~/Views/manageproduct.cshtml");
        }
    }
}
