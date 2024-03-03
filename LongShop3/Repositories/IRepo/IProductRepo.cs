using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LongShop3.Repositories.IRepo
{
    public interface IProductRepo
    {
        public List<ProductWithImageColor> GetAllProduct(int CategoryId, int BrandId, string sort, int offset, int count);
        ProductWithImageColor GetProductDetailById(int id, int colorid);
        public List<ProductWithImageColor> SearchByName(string? name);
        public int GetNumberofproduct(int CategoryId, int BrandId);
        List<ProductWithImageColor> GetAllProductForAdmin(int categoryId, int brandId, string sort, int offset, int count);
        Product_Brand_Cate GetProductDetailInfor(int id);
        List<Color> GetColorsByProductId(int productid);
        public List<Size> GetSizesByProductIdAndColorId(int productId, int colorId);
        public void AddtoCartRepo(int pid, int cid, int sid, int quantity, string username);
    }
}
