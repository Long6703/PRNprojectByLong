using LongShop3.Models;

namespace LongShop3.Repositories.IRepo
{
    public interface IUserRepo
    {
        public User GetUser(string name, string pass);

        public List<Feature> getAllFeature(string name);
        bool signup(User user);
    }
}
