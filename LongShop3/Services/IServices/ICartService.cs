using LongShop3.Models;

namespace LongShop3.Services.IServices
{
    public interface ICartService
    {
        List<Cart> getListCart(string username);
    }
}
