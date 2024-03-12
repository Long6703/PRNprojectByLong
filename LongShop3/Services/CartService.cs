using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;

namespace LongShop3.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;

        public CartService(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public bool deleteAllcart(string username)
        {
            return _cartRepo.deleteAllcartRepo(username);
        }

        public List<Product_Size_Color_Stock> getListCart(string username)
        {
            return _cartRepo.getallCart(username);
        }
    }
}
