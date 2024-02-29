using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public ProductWithImageColor GetProductDetailById(int id, string color)
        {
            List<ProductWithImageColor> list = getAll();
            foreach (ProductWithImageColor item in list)
            {
                if(item.pd.ProductDetailId == id && color.Equals(item.color.ColorName))
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
                             color = new Color { ColorName = c.ColorName },
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
            List<ProductWithImageColor> list = getAll();

            if (categoryId != 0)
            {
                list = list.Where(x => x.pd.CategoryId == categoryId && x.pd.IsActive == true).ToList();
            }

            if (brandId != 0)
            {
                list = list.Where(x => x.pd.BrandId == brandId && x.pd.IsActive == true).ToList();
            }

            list = SortProduct(list, sort);

            return list.Skip(offset).Take(count).ToList();
        }
    }
}
