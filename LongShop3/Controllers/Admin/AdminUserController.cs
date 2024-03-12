using LongShop3.Controllers.Authen;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    [AuthenClass]
    public class AdminUserController : Controller
    {
        [Route("/manageuser")]
        public IActionResult ManageUser()
        {
            return View("~/Views/manageuser.cshtml");
        }
    }
}
