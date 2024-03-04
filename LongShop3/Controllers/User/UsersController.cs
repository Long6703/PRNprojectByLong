using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LongShop3.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly IProductServicecs _productServicecs;

        public UsersController(IProductServicecs productServicecs)
        {
            _productServicecs = productServicecs;
        }

        [Route("/userprofile")]
        public IActionResult UserProfile()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            List<Address> addresses = sHOPLONG5Context.Addresses.Where(x => x.Username.Equals(user.Username)).ToList();
            ViewBag.Address = addresses;
            return View("~/Views/UserProfile.cshtml", user);
        }


        [Route("/editprofile")]
        public IActionResult EditProfile()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            List<Address> addresses = sHOPLONG5Context.Addresses.Where(x => x.Username.Equals(user.Username)).ToList();
            ViewBag.Address = addresses;
            return View("~/Views/EditProfile.cshtml", user);
        }

        [Route("/addnewaddress")]
        public IActionResult AddnewAddress(string address)
        {
            if (address == null)
            {
                return Redirect("editprofile");
            }
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            Address a = new Address();
            a.Username = user.Username;
            a.AddressName = address;
            sHOPLONG5Context.Addresses.Add(a);
            sHOPLONG5Context.SaveChanges();
            return Redirect("editprofile");
        }

        [Route("/doEdit")]
        public IActionResult doProfile(string DisplayName, string Email, string PhoneNumber)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            var olduser = sHOPLONG5Context.Users.FirstOrDefault(x => x.Username.Equals(user.Username));
            olduser.DisplayName = DisplayName;
            olduser.Email = Email;
            olduser.PhoneNumber = PhoneNumber;
            sHOPLONG5Context.SaveChanges();
            HttpContext.Session.Remove("user");
            HttpContext.Session.SetString("user", JsonSerializer.Serialize(olduser));
            return Redirect("userprofile");
        }

        [Route("/dochangepass")]
        public IActionResult dochangePass(string currentPassword, string newPassword, string confirmPassword)
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            if (currentPassword.Equals(user.Password))
            {
                if(newPassword.Equals(confirmPassword))
                {
                    var u = sHOPLONG5Context.Users.FirstOrDefault(x => x.Username == user.Username);
                    u.Password = newPassword;
                    sHOPLONG5Context.SaveChanges();
                    return Redirect("login");
                }
                Console.WriteLine("new pass not match confirm new pass");
                return View("~/Views/Changepassword.cshtml");
            }
            Console.WriteLine("Not match currenrPAss");
            return View("~/Views/Changepassword.cshtml");
        }

        [Route("/changepass")]
        public IActionResult changePass(string currentPassword, string newPassword, string confirmPassword)
        {
            return View("~/Views/Changepassword.cshtml");
        }

        [Route("/doshopping")]
        public IActionResult DoShopping(int pdid, int colorid, string sizename, int quanity)
        {
            string buttonValue = Request.Form["submit"];
            if (buttonValue.Equals("buy"))
            {
                return View("~/Views/Buying.cshtml");
            }

            if (buttonValue.Equals("addtocard"))
            {
                ViewBag.Addsucess = false;
                SHOPLONG5Context context = new SHOPLONG5Context();
                if ("".Equals(sizename))
                {
                    return View("Error");
                }
                Models.Size size = context.Sizes.FirstOrDefault(x => x.SizeName.Equals(sizename));
                int sizeid = 0;
                if (size != null)
                {
                    sizeid = size.SizeId;
                }
                Console.WriteLine($"pid = {pdid}, colorid ; {colorid}, sizename : {sizename}, quantity : {quanity}");
                _productServicecs.AddtoCart(pdid, colorid, sizeid, quanity, "longnk");
                ViewBag.Addsucess = true;
                return Redirect($"productdetail?Id={pdid}&Color={colorid}&AddSuccess=true");
            }

            return View("Error");
        }
    }
}

