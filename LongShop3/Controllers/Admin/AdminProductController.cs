using LongShop3.Controllers.Authen;
using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LongShop3.Controllers.Admin
{
    [AuthenClass]
    public class AdminProductController : Controller
    {
        private readonly IProductServicecs _productServicecs;
        public AdminProductController(IProductServicecs productServicecs)
        {
            _productServicecs = productServicecs;
        }

        [Route("/manageproduct")]
        public IActionResult ManageProduct(int CategoryId, int BrandId, string status, string sort, int page = 1)
        {
            if (page <= 0)
            {
                page = 1;
            }
            int pagesize = 13;
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.DisplayName;
            List<ProductDetail> list = _productServicecs.GetAllProductForAdmin(CategoryId, BrandId, sort, (page - 1) * pagesize, pagesize, status);
            if (list.Count == 0)
            {
                ViewBag.Err = "We have not this product :(((";
            }
            SHOPLONG5Context context = new SHOPLONG5Context();
            int totalproduct = context.ProductDetails.ToList().Count;
            int totalpage = (int)Math.Ceiling((double)totalproduct / pagesize);
            if (totalpage == 0)
            {
                totalpage = 1;
            }
            ViewBag.Status = status;
            ViewBag.totalpage = totalpage;
            ViewBag.currentpage = page;
            ViewBag.CategoryId = CategoryId;
            ViewBag.BrandId = BrandId;
            ViewBag.sort = sort;
            return View("~/Views/manageproduct.cshtml", list);
        }

        [Route("/searchbyname_admin")]
        public IActionResult SearchProduct(string name)
        {
            if(name == "")
            {
                return Redirect("manageproduct");
            }
            SHOPLONG5Context context = new SHOPLONG5Context();
            List<ProductDetail> list = context.ProductDetails.ToList();
            list = list.Where(x => x.ProductName.Contains(name)).ToList();
            return View("~/Views/manageproduct.cshtml", list);
        }

        [Route("/detailproductforadmin")]
        public IActionResult DetailProduct(int ProductDetailId)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.Username;
            return View("~/Views/DetailProduct.cshtml");
        }
    }
}
