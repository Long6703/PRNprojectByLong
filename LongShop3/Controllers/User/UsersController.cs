using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Users
{
    public class UsersController : Controller
    {
        [Route("/userprofile")]
        public IActionResult UserProfile()
        {
            return View("~/Views/UserProfile.cshtml");
        }
    }
}
