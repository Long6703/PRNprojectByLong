using LongShop3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace LongShop3.Controllers
{
    public class BuyController : Controller
    {
        [Route("/completeorder")]
        public IActionResult Completeorder(int commonid, int location_shipping, double totalprice, int amount)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            Order order = new Order();
            order.Username = user.Username;
            order.TotalPrice = (decimal)totalprice;
            order.StatusOrder = "processing";
            order.OrderDate = DateTime.Now.ToString();
            order.Addressid = location_shipping;
            SHOPLONG5Context context = new SHOPLONG5Context();
            context.Orders.Add(order);
            context.SaveChanges();
            int orderid = order.Orderid;
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.CommonId = commonid;
            orderDetail.Amount = amount;
            orderDetail.Orderid = orderid;
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
            var scs = context.SizeColorStocks.FirstOrDefault(x => x.CommonId == commonid);
            if (scs != null)
            {
                scs.QuantityStock = scs.QuantityStock - amount;
            }
            context.SaveChanges();
            return View("~/Views/thankyou.cshtml");
        }

        [Route("/completeorderincart")]
        public IActionResult CompleteorderInCart()
        {
            IQueryCollection queryCollection = HttpContext.Request.Query;
            SHOPLONG5Context context = new SHOPLONG5Context();
            double totalprice = 0;
            int location_shipping = 0;
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            foreach (var parameter in queryCollection)
            {
                if (parameter.Key == "totalprice")
                {
                    totalprice = Double.Parse(parameter.Value);
                }
                if (parameter.Key == "location_shipping")
                {
                    location_shipping = int.Parse(parameter.Value);
                }
            }

            Order order = new Order();
            order.Username = user.Username;
            order.TotalPrice = (decimal)totalprice;
            order.StatusOrder = "processing";
            order.OrderDate = DateTime.Now.ToString();
            order.Addressid = location_shipping;
            context.Orders.Add(order);
            context.SaveChanges();

            foreach (var parameter in queryCollection)
            {
                string paramName = parameter.Key; 
                string paramValue = parameter.Value;
                int commonid = 0;
                int amount = 0;
                if (paramName == "commonid")
                {
                    commonid = int.Parse(paramValue);
                }
                if (paramName == "amount")
                {
                    amount = int.Parse(paramValue);
                }
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.CommonId = commonid;
                orderDetail.Amount = amount;
                orderDetail.Orderid = order.Orderid;
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            return View("~/Views/thankyou.cshtml");
        }
    }
}
