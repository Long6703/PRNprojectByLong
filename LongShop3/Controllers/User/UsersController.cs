using LongShop3.Models;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text.Json;

namespace LongShop3.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly IProductServicecs _productServicecs;
        private readonly IOrderService _orderService;

        public UsersController(IProductServicecs productServicecs, IOrderService orderService)
        {
            _productServicecs = productServicecs;
            _orderService = orderService;
        }

        [Route("/userprofile")]
        public IActionResult UserProfile()
        {
            var userJson = HttpContext.Session.GetString("user");
            var user = JsonSerializer.Deserialize<User>(userJson);
            foreach (var item in user.Addresses)
            {
                Console.WriteLine(item.AddressName);
            }
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
            var usergetdb = sHOPLONG5Context.Users.FirstOrDefault(x => x.Username == user.Username);
            List<Address> addresses = sHOPLONG5Context.Addresses.Where(x => x.Username.Equals(user.Username)).ToList();
            ViewBag.Address = addresses;
            return View("~/Views/EditProfile.cshtml", usergetdb);
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
                ViewBag.selling = true;
                ViewBag.err = true;
                var userJson = HttpContext.Session.GetString("user");
                var user = JsonSerializer.Deserialize<User>(userJson);
                using(SHOPLONG5Context context = new SHOPLONG5Context())
                {
                    List<Address> list = context.Addresses.Where(x => x.Username == user.Username).ToList();
                    ViewBag.Address = list;
                    Size s = context.Sizes.FirstOrDefault(x => x.SizeName == sizename);
                    if(s == null)
                    {
                        ViewBag.err = false;
                        return Redirect($"productdetail?Id={pdid}&Color={colorid}&err=" + ViewBag.err);
                    }
                    int sid = s.SizeId;
                    SizeColorStock scs = context.SizeColorStocks.FirstOrDefault(x => x.ProductDetailId == pdid && x.SizeId == sid && x.ColorId == colorid);
                    Console.WriteLine(scs.CommonId);
                    if (quanity > scs.QuantityStock)
                    {
                        ViewBag.selling = false;
                        return Redirect($"productdetail?Id={pdid}&Color={colorid}&Addselling=" + ViewBag.selling);
                    }
                    ViewBag.quantity = quanity;
                    Product_Size_Color_Stock productinfor = _orderService.getProductinfor(scs.CommonId);
                    return View("~/Views/Buying.cshtml", productinfor);
                }
            }

            if (buttonValue.Equals("addtocard"))
            {
                ViewBag.Addsucess = false;
                ViewBag.selling = true;
                ViewBag.err = true;
                var userJson = HttpContext.Session.GetString("user");
                var user = JsonSerializer.Deserialize<User>(userJson);
                SHOPLONG5Context context = new SHOPLONG5Context();
                Models.Size size = context.Sizes.FirstOrDefault(x => x.SizeName.Equals(sizename));
                if (size == null)
                {
                    ViewBag.err = false;
                    return Redirect($"productdetail?Id={pdid}&Color={colorid}&err=" + ViewBag.err);
                }
                int sizeid = size.SizeId;
                Console.WriteLine($"pid = {pdid}, colorid ; {colorid}, sizename : {sizename}, quantity : {quanity}");
                SizeColorStock scs = context.SizeColorStocks.FirstOrDefault(x => x.ProductDetailId == pdid && x.SizeId == sizeid && x.ColorId == colorid);
                Console.WriteLine(scs.CommonId);
                if (quanity > scs.QuantityStock)
                {
                    ViewBag.selling = false;
                    return Redirect($"productdetail?Id={pdid}&Color={colorid}&Addselling=" + ViewBag.selling);
                }
                if (_productServicecs.AddtoCart(pdid, colorid, sizeid, quanity, user.Username))
                {
                    ViewBag.Addsucess = true;
                }
                return Redirect($"productdetail?Id={pdid}&Color={colorid}&AddSuccess="+ViewBag.Addsucess);
            }

            return View("Error");
        }

        [Route("/upload_avatar")]
        [HttpPost]
        public async Task<IActionResult> Upload_avatarAsync(string username, IFormFile avatar)
        {
            if (avatar == null || avatar.Length == 0)
            {
                return Redirect("editprofile");
            }
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            Guid uniqueGuid = Guid.NewGuid();
            string uniqueString = uniqueGuid.ToString();
            var filename = username + "_" + avatar.FileName + "_" + uniqueString;
            var filePath = Path.Combine(uploadsFolder, filename);
            Console.WriteLine("uploadsFolder " + uploadsFolder);
            Console.WriteLine("filePath : " + filePath);
            Console.WriteLine("username : " + username);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await avatar.CopyToAsync(stream);
            }
            SHOPLONG5Context context = new SHOPLONG5Context();
            var currentuser = context.Users.FirstOrDefault(x => x.Username == username);
            if (currentuser != null)
            {
                currentuser.AvatarUrl = filename;
                context.Update(currentuser);
                context.SaveChanges();
            }
            return Redirect("editprofile");
        }
    }
}

