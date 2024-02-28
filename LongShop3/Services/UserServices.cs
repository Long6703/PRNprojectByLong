using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;

namespace LongShop3.Services
{
    
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _urepo;
        public UserServices(IUserRepo urepo)
        {
            _urepo = urepo;
        }

        public void getAllFeature(string username)
        {
            
        }

        public User getUser(string username, string pass)
        {
            var user = _urepo.GetUser(username, pass);
            return user;
        }
    }
}
