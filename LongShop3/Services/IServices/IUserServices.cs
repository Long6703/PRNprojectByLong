using LongShop3.Models;

namespace LongShop3.Services.IServices
{
    public interface IUserServices
    {
        public User getUser(string username, string pass);
        public void getAllFeature(string username);
        public bool SignUp(User user);

    }
}
