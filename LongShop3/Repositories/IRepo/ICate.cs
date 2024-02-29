using LongShop3.Models;
namespace LongShop3.Repositories.IRepo
{
    public interface ICate
    {
        void AddCate(Category cate);
        public List<Category> GetAllCate();
        List<Category> GetAllCateForAdmin();
        Category GetCateByID(int id);
        void UpdateCate(Category cate);
    }
}
