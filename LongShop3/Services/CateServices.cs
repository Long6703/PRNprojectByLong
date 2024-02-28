using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;

namespace LongShop3.Services
{
    public class CateServices : ICateServices
    {
        public readonly ICate _cate;

        public CateServices(ICate cate)
        {
            _cate = cate;
        }

        public List<Category> GetAllCate()
        {
           return _cate.GetAllCate();
        }
    }
}
