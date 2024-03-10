using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LongShop3.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Route("/viewcart")]
        public IActionResult ViewCart()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            SHOPLONG5Context context = new SHOPLONG5Context();
            List<Address> listadd = context.Addresses.Where(x => x.Username == user.Username).ToList();
            ViewBag.Address = listadd;
            List<Product_Size_Color_Stock> list = _cartService.getListCart(user.Username);
            return View("~/Views/Cart.cshtml", list);
        }

        [Route("/deletecart")]
        public IActionResult DeleteCart(int cartid)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            using(SHOPLONG5Context context = new SHOPLONG5Context())
            {
                Console.WriteLine(cartid);
                Cart cart = context.Carts.FirstOrDefault(x => x.Cartid == cartid && x.Username == user.Username);
                if(cart != null)
                {
                    context.Carts.Remove(cart);
                    context.SaveChanges();
                    return Redirect("viewcart");
                }
            }
            return Redirect("viewcart");

        }
    }
}
