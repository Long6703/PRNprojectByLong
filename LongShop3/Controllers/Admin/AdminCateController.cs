using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Controllers.Admin
{
    public class AdminCateController : Controller
    {
        private readonly ICateServices _cateservice;

        public AdminCateController(ICateServices cateservice)
        {
            _cateservice = cateservice;
        }

        [Route("/managecate")]
        public IActionResult ManageCategories()
        {
            List<Category> categories = _cateservice.GetAllCateForAdmin();
            return View("~/Views/managecate.cshtml", categories);
        }

        [Route("/addnewcate")]
        public IActionResult AddCategories(string newcate)
        {

            if (string.IsNullOrEmpty(newcate))
            {
                return Redirect("managecate");
            }
            Category category = new Category();
            category.CategoryName = newcate;
            _cateservice.AddCate(category);
            return Redirect("managecate");
        }

        [Route("/editcate")]
        public IActionResult EditCate(int ID)
        {
            List<Category> categories = _cateservice.GetAllCateForAdmin();
            Category c = _cateservice.GetCateById(ID);
            ViewBag.Cate = c;
            return View("~/Views/managecate.cshtml", categories);
        }

        [Route("/updateCate")]
        public IActionResult updatecate(Category newCate)
        {
            _cateservice.UpdateCate(newCate);
            return Redirect("managecate");
        }
    }
}
