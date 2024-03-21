using LongShop3.Controllers.Authen;
using LongShop3.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using LongShop3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LongShop3.Controllers.Admin
{
    [AuthenClass]
    public class AdminUserController : Controller
    {
        private readonly IUserServices _userServices;

        public AdminUserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("/manageuser")]
        public IActionResult ManageUser(string name, int role, int page = 1)
        {
            if (page <= 0) 
            {
                page = 1;
            }
            int pagesize = 10;
            List<User> users = _userServices.getAllUserDetailForAdmin(name, role, (page - 1) * pagesize, pagesize);
            int totalUser = _userServices.NumberOfAllUserDetail(name, role);
            int totalpage = (int)Math.Ceiling((double)totalUser / pagesize);
            if (totalpage == 0)
            {
                totalpage = 1;
            }
            ViewBag.totalpage = totalpage;
            ViewBag.currentpage = page;
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                List<Group> groups = context.Groups.ToList();
                ViewBag.Groups = groups;
            }
            if (name != null)
            {
                ViewBag.name = name;
            }

            if(role != 0)
            {
                ViewBag.role = role;
            }
            return View("~/Views/manageuser.cshtml", users);
        }
    }
}
