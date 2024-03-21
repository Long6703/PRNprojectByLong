using LongShop3.Controllers.Authen;
using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace LongShop3.Controllers
{
    [AuthenClass]
    public class BuyController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public BuyController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

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
                    Console.WriteLine("totalprice : " + totalprice);
                }
                if (parameter.Key == "location_shipping")
                {
                    location_shipping = int.Parse(parameter.Value);
                    Console.WriteLine("location_shipping : " + location_shipping);
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
            foreach (var p in queryCollection)
            {
                string parameterName = p.Key;
                int commonid = 0;
                if (parameterName.StartsWith("amount_"))
                {
                    string[] result = parameterName.Split('_');
                    if (result.Length > 0)
                    {
                        commonid = int.Parse(result[1]);
                    }
                    Console.WriteLine("commoid of amout_" + commonid + " : " + p.Value);
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.CommonId = commonid;
                    orderDetail.Amount = int.Parse(p.Value);
                    orderDetail.Orderid = order.Orderid;
                    context.OrderDetails.Add(orderDetail);
                    var scs = context.SizeColorStocks.FirstOrDefault(x => x.CommonId == commonid);
                    if (scs != null)
                    {
                        scs.QuantityStock = scs.QuantityStock - orderDetail.Amount;
                    }
                    context.SaveChanges();
                }
            }
            if (_cartService.deleteAllcart(user.Username))
            {
                return View("~/Views/thankyou.cshtml");
            }

            return View("Error");
        }

        [Route("/orderhistory")]
        public IActionResult OrderHistory()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            List<Order> listorder = _orderService.getOrdersByUser(user.Username);
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            List<Address> listaddress = sHOPLONG5Context.Addresses.ToList();
            return View("~/Views/orderhistory.cshtml", listorder);
        }

        [Route("/orderdetailhistory")]

        public IActionResult OrderHistory(int orderid)
        {
            List<OrderDetail> orderDetails = _orderService.GetOrderDetails(orderid);
            foreach (var orderDetail in orderDetails)
            {
                Console.WriteLine(orderDetail.Common.ProductDetail.ProductName);
            }
            return View("~/Views/orderdetailhistory.cshtml", orderDetails);
        }
    }
}
