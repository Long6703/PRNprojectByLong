﻿using LongShop3.Models;
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

        public bool AddtoCart(int pid, int cid, int sid, int quantity, string username)
        {
            return _repo.AddtoCartRepo(pid, cid, sid, quantity, username);
        }

        public List<ProductWithImageColor> getAll()
        {
            return _repo.getAll();
        }

        public List<Color> getAllColor()
        {
            return _repo.getAllColor();
        }

        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count)
        {
            return _repo.GetAllProduct(CategoryId, BrandId, sort, offset, count);
        }

        public List<ProductDetail> GetAllProductForAdmin(int CategoryId, int BrandId, string sort, int offset, int count, string status)
        {
            return _repo.GetAllProductForAdmin(CategoryId, BrandId, sort, offset, count, status);
        }

        public List<SizeColorStock_Size> getallProductInforforAdmin(int productid, int colorid)
        {
            return _repo.getallProductInforforAdmin(productid, colorid);
        }

        public List<Color> getcolorsbypdid(int productid)
        {
            return _repo.GetColorsByProductId(productid);
        }

        public int GetNumberofproduct(int CategoryId, int BrandId)
        {
            return _repo.GetNumberofproduct(CategoryId, BrandId);
        }

        public ProductWithImageColor GetProductDetail(int Id, int colorid)
        {
            return _repo.GetProductDetailById(Id, colorid);
        }

        public ProductWithImageColor GetProductDetailByIdForAdmin(int id, int colorid)
        {
            return _repo.GetProductDetailByIdForAdmin(id, colorid);
        }

        public Product_Brand_Cate GetProductDetailInfor(int Id)
        {
            return _repo.GetProductDetailInfor(Id);
        }

        public List<Size> GetSizeList()
        {
            return _repo.GetSizeList();
        }

        public List<Size> GetSizesByProductIdAndColorId(int productId, int colorId)
        {
            return _repo.GetSizesByProductIdAndColorId(productId, colorId);
        }

        public List<ProductWithImageColor> SearchByName(string? name)
        {
            return _repo.SearchByName(name);
        }
    }
}
