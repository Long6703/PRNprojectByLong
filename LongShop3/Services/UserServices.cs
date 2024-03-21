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

        public List<User> getAllUserDetailForAdmin(string name, int role, int offset, int count)
        {
            return _urepo.GetAllUserDetailForAdminRepo(name, role, offset, count);
        }

        public List<Group> getRole(string username)
        {
            return _urepo.getRoleRepo(username);
        }

        public User getUser(string username, string pass)
        {
            var user = _urepo.GetUser(username, pass);
            return user;
        }

        public int NumberOfAllUserDetail(string name, int role)
        {
            return _urepo.NumberOfAllUserDetailRepo(name, role);
        }

        public bool SignUp(User user)
        {
            return _urepo.signup(user);
        }
    }
}
