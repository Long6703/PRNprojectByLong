using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Repositories.IRepo
{
    public interface IProductRepo
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort);
        ProductWithImageColor GetProductDetailById(int id, string color);
        public List<ProductWithImageColor> SearchByName(string? name);
    }
}
