using LongShop3.Controllers.Authen;
using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace LongShop3.Controllers.Admin
{
    [AuthenClass]
    public class AdminOrderController : Controller
    {
        private readonly IOrderService _orderService;

        public AdminOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("/manageorder")]
        public IActionResult ManageOrder(string name, int page = 1)
        {
            if (page <= 0)
            {
                page = 1;
            }
            int pageSize = 10;
            List<Order> orders = null;
            using (var context = new SHOPLONG5Context())
            {
                var query = from o in context.Orders
                            join a in context.Addresses on o.Addressid equals a.AddressId
                            select new Order
                            {
                                Orderid = o.Orderid,
                                Username = o.Username,
                                TotalPrice = o.TotalPrice,
                                StatusOrder = o.StatusOrder,
                                OrderDate = o.OrderDate,
                                Address = a
                            };

                if (name != null)
                {
                    query = query.Where(x => x.Username == name);
                    ViewBag.name = name;
                }
                int totalOrders = query.Count();
                int totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);
                if (totalPages == 0)
                {
                    totalPages = 1;
                }
                ViewBag.totalpage = totalPages;
                ViewBag.currentpage = page;
                orders = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            return View("~/Views/manageorder.cshtml", orders);
        }

        [Route("/orderdetailforadmin")]

        public IActionResult OrderDetailForAdmin(int orderid)
        {
            List<OrderDetail> orderdeatil = _orderService.GetOrderDetails(orderid);
            return View("~/Views/orderdetailforadmin.cshtml", orderdeatil);
        }
    }
}
