using LongShop3.Models;

namespace LongShop3.Services.IServices
{
    public interface ICartService
    {
        List<Product_Size_Color_Stock> getListCart(string username);
    }
}
