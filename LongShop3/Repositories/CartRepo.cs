using LongShop3.Models;
using LongShop3.Repositories.IRepo;

namespace LongShop3.Repositories
{
    public class CartRepo : ICartRepo
    {
        public List<Cart> getall(string username)
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            return null;
        }
    }
}
