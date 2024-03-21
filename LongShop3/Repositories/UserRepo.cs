using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public List<User> GetAllUserDetailForAdminRepo(string name, int role, int offset, int count)
        {
            List<User> users = null;
            using(SHOPLONG5Context context = new SHOPLONG5Context())
            {
                users = context.Users.Include(x => x.Addresses).Include(x => x.GroupAccounts).ThenInclude(x => x.Group).ToList();
            }

            if (name != null)
            {
                users = users.Where(x => x.Username.Contains(name)).ToList();
            }

            if (role != 0)
            {
                users = users.Where(x => x.GroupAccounts.Any(g => g.Group.GroupId == role)).ToList();
            }

            return users.Skip(offset).Take(count).ToList();
        }

        public List<Group> getRoleRepo(string username)
        {
            using(SHOPLONG5Context context = new SHOPLONG5Context())
            {
                var query = from g in context.Groups
                            join ga in context.GroupAccounts on g.GroupId equals ga.GroupId
                            where ga.Username == username
                            select new Group
                            {
                                GroupId = g.GroupId,
                                GroupName = g.GroupName
                            };
                return query.ToList();
            }
        }

        public User GetUser(string name, string pass)
        {
            SHOPLONG5Context _context = new SHOPLONG5Context();
            return _context.Users.FirstOrDefault
                (x => x.Username.Equals(name) && x.Password.Equals(pass) && x.IsActive == true);
        }

        public int NumberOfAllUserDetailRepo(string name, int role)
        {
            List<User> users = null;
            using (SHOPLONG5Context context = new SHOPLONG5Context())
            {
                users = context.Users.Include(x => x.Addresses).Include(x => x.GroupAccounts).ThenInclude(x => x.Group).ToList();
            }

            if (name != null)
            {
                users = users.Where(x => x.Username.Contains(name)).ToList();
            }

            if (role != 0)
            {
                users = users.Where(x => x.GroupAccounts.Any(g => g.Group.GroupId == role)).ToList();
            }

            return users.Count;
        }

        public bool signup(User user)
        {
            using (SHOPLONG5Context _context = new SHOPLONG5Context())
            {
                try
                {
                    var userold = _context.Users.FirstOrDefault(x => x.Username.Equals(user.Username));
                    if (userold != null)
                    {
                        Console.WriteLine("Duplicate user name, username is primary key");
                        return false;
                    }
                    _context.Users.Add(user);
                    GroupAccount ga = new GroupAccount();
                    ga.Username = user.Username;
                    ga.GroupId = 1;
                    string test = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ga.Createat = test;
                    _context.GroupAccounts.Add(ga);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
