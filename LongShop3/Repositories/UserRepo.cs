using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;
using System;

namespace LongShop3.Repositories
{
    public class UserRepo : IUserRepo
    {

        public List<Feature> getAllFeature(string name)
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            User user = new User();
            return null;
        }

        public User GetUser(string name, string pass)
        {
            SHOPLONG5Context _context = new SHOPLONG5Context();
            return _context.Users.FirstOrDefault
                (x => x.Username.Equals(name) && x.Password.Equals(pass) && x.IsActive == true);
        }
    }
}
