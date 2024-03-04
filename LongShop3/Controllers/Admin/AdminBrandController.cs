using LongShop3.Controllers.Authen;
using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LongShop3.Controllers.Admin
{
    [AuthenClass]
    public class AdminBrandController : Controller
    {
        private readonly IBrandService _brandService;

        public AdminBrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [Route("/managebrands")]
        public IActionResult ManageBrands()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.DisplayName;
            List<Brand> brands = _brandService.GetBrandsForAdmin();
            return View("~/Views/managebrands.cshtml", brands);
        }

        [Route("/addnewbrand")]
        public IActionResult AddNewBrands(string newbrand)
        {
            if(string.IsNullOrEmpty(newbrand))
            {
                ViewBag.Err = (string)"Invalid input";
                Console.WriteLine(ViewBag.Err);
                return Redirect("managebrands");
            }
            Brand brand = new Brand();
            brand.BrandName = newbrand;
            _brandService.AddBrand(brand);
            return Redirect("managebrands");
        }

        [Route("/editbrand")]
        public IActionResult EditBrands(int ID)
        {
            List<Brand> brands = _brandService.GetBrandsForAdmin();
            Brand b = _brandService.getBrandsByID(ID);
            ViewBag.brand = b;
            return View("~/Views/managebrands.cshtml", brands);
        }

        [Route("/updateBrand")]
        public IActionResult UpdateBrands(Brand newbrand)
        {
            Console.WriteLine(newbrand.BrandId + newbrand.BrandName + newbrand.IsActive.ToString());
            _brandService.UpdateBrand(newbrand);
            return Redirect("managebrands");
        }

    }
}
