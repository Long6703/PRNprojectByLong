using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;

namespace LongShop3.Services
{
    
    public class CateRepo : IUserServices
    {
        private readonly IUserRepo _urepo;
        public CateRepo(IUserRepo urepo)
        {
            _urepo = urepo;
        }

        public void getAllFeature(string username)
        {
            
        }

        public Group getRole(string username)
        {
            return _urepo.getRoleRepo(username);
        }

        public User getUser(string username, string pass)
        {
            var user = _urepo.GetUser(username, pass);
            return user;
        }

        public bool SignUp(User user)
        {
            return _urepo.signup(user);
        }
    }
}
