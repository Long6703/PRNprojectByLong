using LongShop3.Models;

namespace LongShop3.Repositories.IRepo
{
    public interface ICartRepo
    {
        bool deleteAllcartRepo(string username);
        public List<Product_Size_Color_Stock> getallCart(string username);
    }
}
