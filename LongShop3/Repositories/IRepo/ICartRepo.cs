using LongShop3.Models;

namespace LongShop3.Repositories.IRepo
{
    public interface ICartRepo
    {
        public List<Cart> getall(string username);
    }
}
