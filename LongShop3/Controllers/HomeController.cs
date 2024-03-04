using LongShop3.Controllers.Authen;
using LongShop3.Models;
using LongShop3.Repositories;
using LongShop3.Services;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace LongShop3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICateServices _cateServices;
        public HomeController(ICateServices cateServices)
        {
            _cateServices = cateServices;
        }

        [Route("/home")]
        public IActionResult Index()
        {
            var listCate = _cateServices.GetAllCate();
            return View("~/Views/Index.cshtml", listCate);
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View("~/Views/About.cshtml");
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View("~/Views/Contact.cshtml");
        }

        [Route("/accessdenied")]
        public IActionResult accessdenied()
        {
            return View("~/Views/AccessDenied.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
