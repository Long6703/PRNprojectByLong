﻿using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;

namespace LongShop3.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public List<Order> getOrdersByUser(string username)
        {
            return _orderRepo.getOrderhistory(username);
        }

        public Product_Size_Color_Stock getProductinfor(int commonId)
        {
            return _orderRepo.getProductinfor(commonId);
        }

        public List<OrderDetail> GetOrderDetails (int ordeid)
        {
            return _orderRepo.getorderdetailRepo(ordeid);
        }
    }
}
