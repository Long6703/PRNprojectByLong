using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Services
{
    public class ProductService : IProductServicecs
    {
        private readonly IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort)
        {
            return _repo.GetAllProduct(CategoryId, BrandId, sort);
        }

        public ProductWithImageColor GetProductDetail(int Id, string color)
        {
            return _repo.GetProductDetailById(Id, color);
        }

        public List<ProductWithImageColor> SearchByName(string? name)
        {
            return _repo.SearchByName(name);
        }
    }
}
