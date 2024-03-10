using LongShop3.Models;
using LongShop3.Repositories;
using LongShop3.Services.IServices;
using LongShop3.Services;
using Microsoft.AspNetCore.Mvc;
using LongShop3.Controllers.Authen;
using System.Drawing;
using System.Collections.Generic;

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
        public IActionResult Shop(int CategoryId, int BrandId, string sort, int page = 1)
        {

            if (page <= 0)
            {
                page = 1;
            }
            int pagesize = 36;
            List<ProductWithImageColor> listproduct = _productServicecs.GetAllProduct(CategoryId, BrandId, sort, (page - 1) * pagesize, pagesize);
            if (listproduct.Count == 0)
            {
                ViewBag.Err = "We have not this product :(((";
            }

            int totalproduct = _productServicecs.GetNumberofproduct(CategoryId, BrandId);
            int totalpage = (int)Math.Ceiling((double)totalproduct / pagesize);
            if (totalpage == 0)
            {
                totalpage = 1;
            }
            
            ViewBag.totalpage = totalpage;
            ViewBag.currentpage = page;
            ViewBag.CategoryId = CategoryId;
            ViewBag.BrandId = BrandId;
            ViewBag.sort = sort;
            return View("~/Views/Shop.cshtml", listproduct);
        }

        [Route("/searchbyname")]
        public IActionResult SearchbyName(string name)
        {
            if (name == null)
            {
                return RedirectToAction("/shop");
            }
            List<ProductWithImageColor> list = _productServicecs.SearchByName(name);
            ViewBag.Name = (string)name;
            return View("~/Views/Shop.cshtml", list);
        }

        [Route("/productdetail")]
        public IActionResult ProductDetail(int Id, int Color)
        {
            Console.WriteLine(Id + Color);
            ProductWithImageColor pic = _productServicecs.GetProductDetail(Id, Color);
            Product_Brand_Cate product_Brand_Cate = _productServicecs.GetProductDetailInfor(Id);
            ViewBag.infor = product_Brand_Cate;
            List<Models.Color> colors = _productServicecs.getcolorsbypdid(Id);
            ViewBag.colors = colors;
            List<Models.Size> sizes = _productServicecs.GetSizesByProductIdAndColorId(Id, Color);
            ViewBag.sizes = sizes;
            return View("~/Views/Shop-single.cshtml", pic);
        }

    }
}
