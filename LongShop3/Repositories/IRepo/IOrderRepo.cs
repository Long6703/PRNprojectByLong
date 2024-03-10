using LongShop3.Models;

namespace LongShop3.Repositories.IRepo
{
    public interface IOrderRepo
    {
        public Product_Size_Color_Stock getProductinfor(int commonId);

    }
}
