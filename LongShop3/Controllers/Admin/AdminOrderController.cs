using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    public class AdminOrderController : Controller
    {
        [Route("/manageorder")]
        public IActionResult ManageOrder()
        {
            return View("~/Views/manageorder.cshtml");
        }
    }
}
