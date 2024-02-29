using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Services.IServices
{
    public interface IProductServicecs
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count);
        public List<ProductWithImageColor> SearchByName(string? name);
        public ProductWithImageColor GetProductDetail(int Id, string color);
        public int GetNumberofproduct(int CategoryId, int BrandId);
        public List<ProductWithImageColor> GetAllProductForAdmin(int CategoryId, int BrandId, string sort, int offset, int count);
    }
}
