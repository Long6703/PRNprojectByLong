using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Services.IServices
{
    public interface IProductServicecs
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string search);
        public List<ProductWithImageColor> SearchByName(string? name);
        public ProductWithImageColor GetProductDetail(int Id, string color);
    }
}
