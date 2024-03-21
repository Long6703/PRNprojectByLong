using LongShop3.Models;

namespace LongShop3.Repositories.IRepo
{
    public interface IUserRepo
    {
        public User GetUser(string name, string pass);

        public List<Feature> getAllFeature(string name);
        bool signup(User user);
        public List<Group> getRoleRepo(string username);
        List<User> GetAllUserDetailForAdminRepo(string name, int role, int offset, int count);
        int NumberOfAllUserDetailRepo(string name, int role);
    }
}
