using LongShop3.Models;

namespace LongShop3.Services.IServices
{
    public interface IOrderService
    {
        public Product_Size_Color_Stock getProductinfor(int commonId);
        public List<Order> getOrdersByUser(string username);

        public List<OrderDetail> GetOrderDetails(int ordeid);
    }
}
