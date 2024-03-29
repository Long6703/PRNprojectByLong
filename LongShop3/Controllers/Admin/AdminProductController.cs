﻿using LongShop3.Controllers.Authen;
using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
            Dictionary<int, List<Color>> colorDictionary = new Dictionary<int, List<Color>>();
            foreach (var p in list)
            {
                List<Color> listcolor = _productServicecs.getcolorsbypdid(p.ProductDetailId);
                colorDictionary.Add(p.ProductDetailId, listcolor);
            }
            ViewBag.ColorDictionary = colorDictionary;
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
            if(name == null)
            {
                return Redirect("manageproduct");
            }
            SHOPLONG5Context context = new SHOPLONG5Context();
            List<ProductDetail> list = context.ProductDetails.ToList();
            list = list.Where(x => x.ProductName.Contains(name)).ToList();
            Dictionary<int, List<Color>> colorDictionary = new Dictionary<int, List<Color>>();
            foreach (var p in list)
            {
                List<Color> listcolor = _productServicecs.getcolorsbypdid(p.ProductDetailId);
                colorDictionary.Add(p.ProductDetailId, listcolor);
            }
            ViewBag.ColorDictionary = colorDictionary;
            ViewBag.namesearch = name;
            return View("~/Views/manageproduct.cshtml", list);
        }

        [Route("/detailproductforadmin")]
        public IActionResult DetailProduct(int productid, int colorid)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.Username;
            List<Color> listcolor = _productServicecs.getcolorsbypdid(productid);
            ViewBag.listcolor = listcolor;
            ProductWithImageColor productinforwithcolor = _productServicecs.GetProductDetailByIdForAdmin(productid, colorid);
            Category c = null;
            Brand brand = null;
            using(SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var productDetail = context.ProductDetails.FirstOrDefault(pd => pd.ProductDetailId == productid);
                if (productDetail != null)
                {
                    int categoryid = productDetail.CategoryId;
                    int brandid = (int)productDetail.BrandId;
                    c = context.Categories.FirstOrDefault(x => x.CategoryId == categoryid);
                    brand = context.Brands.FirstOrDefault(x => x.BrandId == brandid);
                }
                ViewBag.CateName = c.CategoryName;
                ViewBag.BrandName = brand.BrandName;
                ViewBag.colorid = colorid;
            }
            List<SizeColorStock_Size> inforstock = _productServicecs.getallProductInforforAdmin(productid, colorid);
            if( inforstock != null && inforstock.Count > 0 )
            {
                ViewBag.inforstock = inforstock;
            }
            return View("~/Views/DetailProduct.cshtml", productinforwithcolor);
        }

        [Route("/editproductforadmin")]
        public IActionResult EditProduct(int productid, int colorid)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.Username;
            List<Color> listcolor = _productServicecs.getcolorsbypdid(productid);
            ViewBag.listcolor = listcolor;
            ProductWithImageColor productinforwithcolor = _productServicecs.GetProductDetailByIdForAdmin(productid, colorid);
            Category c = null;
            Brand brand = null;
            List<Size> listsize = null;
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var productDetail = context.ProductDetails.FirstOrDefault(pd => pd.ProductDetailId == productid);
                listsize = context.Sizes.ToList();
                if (productDetail != null)
                {
                    int categoryid = productDetail.CategoryId;
                    int brandid = (int)productDetail.BrandId;
                    c = context.Categories.FirstOrDefault(x => x.CategoryId == categoryid);
                    brand = context.Brands.FirstOrDefault(x => x.BrandId == brandid);
                }
                ViewBag.CateName = c.CategoryName;
                ViewBag.BrandName = brand.BrandName;
                ViewBag.colorid = colorid;
            }
            List<SizeColorStock_Size> inforstock = _productServicecs.getallProductInforforAdmin(productid, colorid);
            ViewBag.AllSizes = listsize;
            ViewBag.AllSizes = listsize;
            if (inforstock != null && inforstock.Count > 0)
            {
                ViewBag.inforstock = inforstock;
            }
            return View("~/Views/EditProduct.cshtml", productinforwithcolor);
        }

        [Route("/updateproduct")]
        public IActionResult UpdateProduct(ProductDetail newproduct, int corlorid)
        {
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var old = context.ProductDetails.FirstOrDefault(x => x.ProductDetailId == newproduct.ProductDetailId);
                if (old != null)
                {
                    old.ProductName = newproduct.ProductName;
                    old.Price = newproduct.Price;
                    old.CategoryId = newproduct.CategoryId;
                    old.Description = newproduct.Description;
                    old.IsActive = newproduct.IsActive;
                    old.BrandId = newproduct.BrandId;
                    context.ProductDetails.Update(old);
                    context.SaveChanges();
                }
            }
            IQueryCollection queryCollection = HttpContext.Request.Query;
            foreach (var item in queryCollection)
            {
                string paramName = item.Key;
                int sizeid = 0;
                if (paramName.StartsWith("sizeid_"))
                {
                    string[] results = paramName.Split('_');
                    sizeid = int.Parse(results[1]);
                    string amountstring = item.Value;
                    if (amountstring != "" && int.Parse(amountstring) > 0)
                    {
                        using (SHOPLONG5Context context = new SHOPLONG5Context())
                        {
                            var old = context.SizeColorStocks.FirstOrDefault(x => x.ProductDetailId == newproduct.ProductDetailId && x.ColorId == corlorid && x.SizeId == sizeid);
                            if (old != null)
                            {
                                old.QuantityStock = int.Parse(amountstring);
                                context.SaveChanges();
                            }else
                            {
                                SizeColorStock scs = new SizeColorStock();
                                scs.SizeId = sizeid;
                                scs.ColorId = corlorid;
                                scs.ProductDetailId = newproduct.ProductDetailId;
                                scs.QuantityStock = int.Parse(amountstring);
                                context.SizeColorStocks.Add(scs);
                                context.SaveChanges();
                            }
                            
                        }
                    }
                }
            }
            return Redirect("manageproduct");
        }

        [Route("/createnewitem")]
        public IActionResult Createnewitem(int productid, int colorid)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.Username;
            List<Size> listsize = null;
            ProductDetail pd = null;
            List<Color> listcolornotavaliable = null;
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                pd = context.ProductDetails.FirstOrDefault(pd => pd.ProductDetailId == productid);
                listsize = context.Sizes.ToList();
                var query = from c in context.Colors
                            where !(from scs in context.SizeColorStocks
                                    where scs.ProductDetailId == productid && scs.ColorId == c.ColorId
                                    select scs.ColorId)
                                    .Any()
                            select c;
                listcolornotavaliable = query.ToList();
            }
            ViewBag.AllSizes = listsize;
            ViewBag.listcolornotavaliable = listcolornotavaliable;
            if (pd != null)
            {
                ViewBag.pdName = pd.ProductName;
                ViewBag.pdid = productid;
            }
            return View("~/Views/createnewitem.cshtml");
        }

        [HttpPost]
        [Route("/docreatenewitem")]
        public async Task<IActionResult> doCreatenewitem(int productid, int selectedColor, List<IFormFile> images)
        {
            long size = images.Sum(f => f.Length);

            if (size == 0)
            {
                return Redirect("createnewitem");
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            foreach (var i in images)
            {
                if(i.Length > 0)
                {
                    Guid uniqueGuid = Guid.NewGuid();
                    string uniqueString = uniqueGuid.ToString();
                    string extension = Path.GetExtension(i.FileName);
                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(i.FileName);
                    string newFilename = $"{filenameWithoutExtension}_{uniqueString}{extension}";
                    Console.WriteLine(newFilename);
                    string filePath = Path.Combine(uploadsFolder, newFilename);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await i.CopyToAsync(stream);
                    }
                    using(SHOPLONG5Context context = new SHOPLONG5Context())
                    {
                        Image image = new Image();
                        image.ProductDetailId = productid;
                        image.ColorId = selectedColor;
                        image.ImageUrl = newFilename;
                        context.Images.Add(image);
                        context.SaveChanges();
                    }
                }
            }
            IFormCollection formCollection = await HttpContext.Request.ReadFormAsync();

            foreach (var item in formCollection)
            {
                string paramName = item.Key;
                int sizeid = 0;
                if (paramName.StartsWith("sizeid_"))
                {
                    string[] results = paramName.Split('_');
                    sizeid = int.Parse(results[1]);
                    string amountstring = item.Value;
                    if (amountstring != "" && int.Parse(amountstring) > 0)
                    {
                        using (SHOPLONG5Context context = new SHOPLONG5Context())
                        {
                            var old = context.SizeColorStocks.FirstOrDefault(x => x.ProductDetailId == productid && x.ColorId == selectedColor && x.SizeId == sizeid);
                            if (old != null)
                            {
                                old.QuantityStock = int.Parse(amountstring);
                                context.SaveChanges();
                            }
                            else
                            {
                                SizeColorStock scs = new SizeColorStock();
                                scs.SizeId = sizeid;
                                scs.ColorId = selectedColor;
                                scs.ProductDetailId = productid;
                                scs.QuantityStock = int.Parse(amountstring);
                                context.SizeColorStocks.Add(scs);
                                context.SaveChanges();
                            }

                        }
                    }
                }
            }
            return Redirect("manageproduct");
        }

        [Route("/creatnewproduct")]
        public IActionResult Createnewproduct()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            ViewBag.Username = user.Username;
            List<Category> cate = null;
            List<Brand> brands = null;
            List<Size> listsize = null;
            List<Color> listcolornotavaliable = null;
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                listsize = context.Sizes.ToList();
                listcolornotavaliable = context.Colors.ToList();
                cate = context.Categories.ToList();
                brands = context.Brands.ToList();
            }
            ViewBag.AllSizes = listsize;
            ViewBag.listcolornotavaliable = listcolornotavaliable;
            ViewBag.cate = cate;
            ViewBag.brands = brands;
            return View("~/Views/createnewproduct.cshtml");
        }

        [Route("/docreatnewproduct")]
        public async Task<IActionResult> DoCreatNewProduct(List<IFormFile> images, ProductDetail newproduct, int selectedColor)
        {
            long size = images.Sum(f => f.Length);

            if (size == 0)
            {
                return Redirect("creatnewproduct");
            }
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                context.ProductDetails.Add(newproduct);
                context.SaveChanges();
            }
            IFormCollection formCollection = await HttpContext.Request.ReadFormAsync();
            foreach (var item in formCollection)
            {
                string paramName = item.Key;
                int sizeid = 0;
                if (paramName.StartsWith("sizeid_"))
                {
                    string[] results = paramName.Split('_');
                    sizeid = int.Parse(results[1]);
                    string amountstring = item.Value;
                    if (amountstring != "" && int.Parse(amountstring) > 0)
                    {
                        using (SHOPLONG5Context context = new SHOPLONG5Context())
                        {
                            SizeColorStock scs = new SizeColorStock();
                            scs.SizeId = sizeid;
                            scs.ColorId = selectedColor;
                            scs.ProductDetailId = newproduct.ProductDetailId;
                            scs.QuantityStock = int.Parse(amountstring);
                            context.SizeColorStocks.Add(scs);
                            context.SaveChanges();
                        }
                    }
                }
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            foreach (var i in images)
            {
                if (i.Length > 0)
                {
                    Guid uniqueGuid = Guid.NewGuid();
                    string uniqueString = uniqueGuid.ToString();
                    string extension = Path.GetExtension(i.FileName);
                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(i.FileName);
                    string newFilename = $"{filenameWithoutExtension}_{uniqueString}{extension}";
                    Console.WriteLine(newFilename);
                    string filePath = Path.Combine(uploadsFolder, newFilename);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await i.CopyToAsync(stream);
                    }
                    using (SHOPLONG5Context context = new SHOPLONG5Context())
                    {
                        Image image = new Image();
                        image.ProductDetailId = newproduct.ProductDetailId;
                        image.ColorId = selectedColor;
                        image.ImageUrl = newFilename;
                        context.Images.Add(image);
                        context.SaveChanges();
                    }
                }
            }
            return Redirect("manageproduct");
        }
    }
}
