using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    public class AdminUserController : Controller
    {
        [Route("/manageuser")]
        public IActionResult ManageUser()
        {
            return View("~/Views/manageuser.cshtml");
        }
    }
}
