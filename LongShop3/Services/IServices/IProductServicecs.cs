using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Services.IServices
{
    public interface IProductServicecs
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count);
        public List<ProductWithImageColor> SearchByName(string? name);
        public ProductWithImageColor GetProductDetail(int Id, int colorid);
        public int GetNumberofproduct(int CategoryId, int BrandId);
        public List<ProductDetail> GetAllProductForAdmin(int CategoryId, int BrandId, string sort, int offset, int count, string status);
        public Product_Brand_Cate GetProductDetailInfor(int Id);
        List<Color> getcolorsbypdid(int productid);
        public List<Size> GetSizesByProductIdAndColorId(int productId, int colorId);
        public bool AddtoCart(int pid, int cid, int sid, int quantity, string username);
    }
}
