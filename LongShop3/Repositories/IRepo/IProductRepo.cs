using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Repositories.IRepo
{
    public interface IProductRepo
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count);
        ProductWithImageColor GetProductDetailById(int id, string color);
        public List<ProductWithImageColor> SearchByName(string? name);
        public int GetNumberofproduct(int CategoryId, int BrandId);
        List<ProductWithImageColor> GetAllProductForAdmin(int categoryId, int brandId, string sort, int offset, int count);
    }
}
