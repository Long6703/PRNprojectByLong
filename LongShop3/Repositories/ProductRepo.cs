using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LongShop3.Repositories
{
    public class ProductRepo : IProductRepo
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count)
        {
            List<ProductWithImageColor> list = getAll();

            if (CategoryId != 0)
            {
                list = list.Where(x => x.pd.CategoryId == CategoryId && x.pd.IsActive == true).ToList();
            }

            if (BrandId != 0)
            {
                list = list.Where(x => x.pd.BrandId == BrandId && x.pd.IsActive == true).ToList();
            }

            list = list.Where(x => x.pd.IsActive == true).ToList();
            list = SortProduct(list, sort);

            return list.Skip(offset).Take(count).ToList();
        }

        public ProductWithImageColor GetProductDetailById(int id, int colorid)
        {
            List<ProductWithImageColor> list = null;
            using (var context = new SHOPLONG5Context())
            {
                // Lấy tất cả các bản ghi và nhóm chúng dựa trên ProductDetailId và ColorId
                var groupedResult = from pd in context.ProductDetails
                                    join i in context.Images on pd.ProductDetailId equals i.ProductDetailId
                                    join c in context.Colors on i.ColorId equals c.ColorId
                                    group new { pd, i, c } by new { pd.ProductDetailId, c.ColorId, c.ColorName } into g
                                    select new ProductWithImageColor
                                    {
                                        pd = g.FirstOrDefault(x => x.pd.IsActive == true).pd,
                                        color = new Color { ColorId = g.Key.ColorId, ColorName = g.Key.ColorName }, 
                                        images = g.Select(x => new Image { ImageId = x.i.ImageId, ImageUrl = x.i.ImageUrl }).ToList()
                                    };

                list = groupedResult.ToList();

            }
            foreach (ProductWithImageColor item in list)
            {
                if(item.pd.ProductDetailId == id && item.color.ColorId == colorid)
                {
                    return item;
                }
            }
            return null;
        }

        

        public List<ProductWithImageColor> SearchByName(string? name)
        {
            if (name == null)
            {
                return null;
            }
            List<ProductWithImageColor> list = getAll();
            return list.Where(x => x.pd.ProductName.Contains(name) && x.pd.IsActive == true).ToList();
        }

        private List<ProductWithImageColor> SortProduct(List<ProductWithImageColor> products, string sort)
        {
            if ("asc".Equals(sort))
            {
                return products.OrderBy(x => x.pd.Price).ToList();
            }

            if ("desc".Equals(sort))
            {
                return products.OrderByDescending(x => x.pd.Price).ToList();
            }

            return products;

        }

        private List<ProductWithImageColor> getAll()
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            var result = from pd in context.ProductDetails
                         join i in context.Images on pd.ProductDetailId equals i.ProductDetailId
                         join c in context.Colors on i.ColorId equals c.ColorId
                         select new ProductWithImageColor
                         {
                             pd = pd,
                             color = new Color { ColorName = c.ColorName, ColorId = c.ColorId },
                             images = new List<Image> { new Image { ImageUrl = i.ImageUrl } }
                         };

            List<ProductWithImageColor> list = result.ToList();
            return list;
        }

        public int GetNumberofproduct(int CategoryId, int BrandId)
        {
            List<ProductWithImageColor> list = getAll();
            if (CategoryId == 0 && BrandId != 0)
            {
                list = list.Where(x => x.pd.BrandId == BrandId).ToList();
                return list.Count();
            }

            if (CategoryId != 0 && BrandId == 0)
            {
                list = list.Where(x => x.pd.CategoryId == CategoryId).ToList();
                return list.Count();
            }

            if (CategoryId != 0 && BrandId != 0)
            {
                list = list.Where(x => x.pd.CategoryId == CategoryId && x.pd.BrandId == BrandId).ToList();
                return list.Count();
            }

            return list.Count();
        }

        public List<ProductWithImageColor> GetAllProductForAdmin(int categoryId, int brandId, string sort, int offset, int count)
        {
            return null;
        }

        public Product_Brand_Cate GetProductDetailInfor(int id)
        {
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var query = (from pd in context.ProductDetails // Thay thế ProductDetails bằng tên DbSet tương ứng trong DbContext
                            join b in context.Brands on pd.BrandId equals b.BrandId // Giả sử thuộc tính là BrandId
                            join ca in context.Categories on pd.CategoryId equals ca.CategoryId // Giả sử thuộc tính là CategoryId
                            where pd.ProductDetailId == id
                            select new Product_Brand_Cate
                            {
                                pd = pd,
                                brand = b,
                                category = ca
                            }).FirstOrDefault();

                return query;
            }
        }

        public List<Color> GetColorsByProductId(int productId)
        {
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var query = (from c in context.Colors
                             join sc in context.SizeColorStocks on c.ColorId equals sc.ColorId
                             where sc.ProductDetailId == productId
                             select new Color
                             {
                                 ColorId = c.ColorId,
                                 ColorName = c.ColorName
                             }).Distinct();

                return query.ToList();
            }
        }

        public List<Size> GetSizesByProductIdAndColorId(int productId, int colorId)
        {
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var query = (from s in context.Sizes
                             join sc in context.SizeColorStocks on s.SizeId equals sc.SizeId
                             where sc.ProductDetailId == productId && sc.ColorId == colorId
                             select new Size
                             {
                                 SizeId = s.SizeId,
                                 SizeName = s.SizeName
                             }).Distinct();

                return query.ToList();
            }
        }

        public void AddtoCartRepo(int pid, int cid, int sid, int quantity, string username)
        {
            bool check = GetOrCreateCart(pid, cid, sid, username, quantity);
            if(check == true)
            {
                Console.WriteLine("Add suecess");
            }
            Console.WriteLine("Fail");
        }

        private bool GetOrCreateCart(int pid, int cid, int sid, string username, int quantity)
        {
            using (var ctx = new SHOPLONG5Context())
            {
                int? commonId = ctx.SizeColorStocks
                                  .Where(x => x.ProductDetailId == pid && x.ColorId == cid && x.SizeId == sid)
                                  .Select(x => x.CommonId)
                                  .FirstOrDefault();

                if (!commonId.HasValue)
                {
                    // Option 1: Trả về null
                    Console.WriteLine("No exist product with pid, sizeid, colorid");
                    return false;

                    // Option 2: Throw an exception
                    // throw new Exception("CommonId not found for the given product details.");
                }

                Cart cart = ctx.Carts
                               .FirstOrDefault(c => c.CommonId == commonId.Value && c.Username.Equals(username));

                var stockRecord = ctx.SizeColorStocks
                  .Where(x => x.CommonId == cart.CommonId)
                  .FirstOrDefault();

                int stock = (int)(stockRecord != null ? stockRecord.QuantityStock : 0);
                if (stock == 0)
                {
                    Console.WriteLine("This product quantity = 0");
                    return false;
                }
                if (quantity > stock)
                {
                    Console.WriteLine("Not enough to sale");
                    return false;
                }

                // Nếu tìm thấy, trả về instance đó
                if (cart != null)
                {
                    cart.Amount = cart.Amount + quantity;
                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    Cart newCart = new Cart
                    {
                        CommonId = commonId.Value,
                        Username = username,
                        CreateAt = DateTime.Now.ToString(),
                        Amount = quantity,
                    };
                    ctx.Carts.Add(newCart);
                    return true;
                }
            }
        }

    }
}
