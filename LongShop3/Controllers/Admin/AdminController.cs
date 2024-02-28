using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    public class AdminController : Controller
    {
        [Route("/manageproduct")]
        public IActionResult ManageProduct()
        {
            return View("~/Views/manageproduct.cshtml");
        }

        [Route("/managebrands")]
        public IActionResult ManageBrands()
        {
            return View("~/Views/managebrands.cshtml");
        }

        [Route("/managecate")]
        public IActionResult ManageCategories()
        {
            return View("~/Views/managecate.cshtml");
        }

        [Route("/manageuser")]
        public IActionResult ManageUser()
        {
            return View("~/Views/manageuser.cshtml");
        }

        [Route("/manageorder")]
        public IActionResult ManageOrder()
        {
            return View("~/Views/manageorder.cshtml");
        }
    }
}
