using LongShop3.Controllers.Authen;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    [AuthenClass]
    public class AdminOrderController : Controller
    {
        [Route("/manageorder")]
        public IActionResult ManageOrder()
        {
            return View("~/Views/manageorder.cshtml");
        }
    }
}
