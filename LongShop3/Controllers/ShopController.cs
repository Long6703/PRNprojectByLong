using LongShop3.Models;
using LongShop3.Repositories;
using LongShop3.Services.IServices;
using LongShop3.Services;
using Microsoft.AspNetCore.Mvc;
using LongShop3.Controllers.Authen;
using System.Drawing;

namespace LongShop3.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductServicecs _productServicecs;

        public ShopController(IProductServicecs productServicecs)
        {
            _productServicecs = productServicecs;
        }

        [Route("/shop")]
        public IActionResult Shop(int CategoryId, int BrandId, string sort)
        {
            ViewBag.CategoryId = CategoryId;
            ViewBag.BrandId = BrandId;
            ViewBag.Sort = (String) sort;
            List<ProductWithImageColor> listproduct = _productServicecs.GetAllProduct(CategoryId, BrandId, sort);
            if(listproduct.Count == 0)
            {
                ViewBag.Err = (String)"We have not this product :(((";
            }
            return View("~/Views/Shop.cshtml", listproduct);
        }

        [Route("/searchbyname")]
        public IActionResult SearchbyName(string? name)
        {
            if(name == null)
            {
                return RedirectToAction("/shop");
            }
            List<ProductWithImageColor> list = _productServicecs.SearchByName(name);
            ViewBag.Name = name;
            return View("~/Views/Shop.cshtml", list);
        }

        [Route("/productdetail")]
        public IActionResult ProductDetail(int Id, string Color)
        {
            Console.WriteLine(Id + Color);
            ProductWithImageColor pic = _productServicecs.GetProductDetail(Id, Color);
            return View("~/Views/Shop-single.cshtml", pic);
        }
    }
}
