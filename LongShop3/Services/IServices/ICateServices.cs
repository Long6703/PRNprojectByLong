using LongShop3.Models;

namespace LongShop3.Services.IServices
{
    public interface ICateServices
    {
        public List<Category> GetAllCate();

        public List<Category> GetAllCateForAdmin();

        public void AddCate(Category cate);

        public Category GetCateById(int id);

        public void UpdateCate(Category cate);
    }
}
