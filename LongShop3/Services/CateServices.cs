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

        public void AddCate(Category cate)
        {
            _cate.AddCate(cate);
        }

        public List<Category> GetAllCate()
        {
           return _cate.GetAllCate();
        }

        public List<Category> GetAllCateForAdmin()
        {
            return _cate.GetAllCateForAdmin();
        }

        public Category GetCateById(int id)
        {
            return _cate.GetCateByID(id);
        }

        public void UpdateCate(Category cate)
        {
            _cate.UpdateCate(cate);
        }
    }
}
