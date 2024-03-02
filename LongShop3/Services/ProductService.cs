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

        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count)
        {
            return _repo.GetAllProduct(CategoryId, BrandId, sort, offset, count);
        }

        public List<ProductWithImageColor> GetAllProductForAdmin(int CategoryId, int BrandId, string sort, int offset, int count)
        {
            return _repo.GetAllProductForAdmin(CategoryId, BrandId, sort, offset, count);
        }

        public int GetNumberofproduct(int CategoryId, int BrandId)
        {
            return _repo.GetNumberofproduct(CategoryId, BrandId);
        }

        public ProductWithImageColor GetProductDetail(int Id, int colorid)
        {
            return _repo.GetProductDetailById(Id, colorid);
        }

        public Product_Brand_Cate GetProductDetailInfor(int Id)
        {
            return _repo.GetProductDetailInfor(Id);
        }

        public List<ProductWithImageColor> SearchByName(string? name)
        {
            return _repo.SearchByName(name);
        }
    }
}
