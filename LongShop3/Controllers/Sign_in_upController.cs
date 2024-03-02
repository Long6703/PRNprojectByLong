using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LongShop3.Controllers
{
    public class Sign_in_upController : Controller
    {
        private readonly IUserServices _userServices;

        public Sign_in_upController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [Route("/dologin")]
        public IActionResult doLogin(string username, string pass)
        {
            User u = _userServices.getUser(username, pass);
            if(u == null)
            {
                return Redirect("/login");
            }
            var serializedUser = JsonSerializer.Serialize(u);
            HttpContext.Session.SetString("user", serializedUser);
            return Redirect("/home");
        }

        [Route("/dosignup")]
        public IActionResult Dosignup(User newuser, string confirmpassword)
        {
            if(newuser.Password != confirmpassword)
            {
                Console.WriteLine("Not match password");
            }
            else
            {
                if (_userServices.SignUp(newuser))
                {
                    Console.WriteLine("Add success");
                    return Redirect("/home");
                }
            }
            return Redirect("/login");
        }
    }
}
