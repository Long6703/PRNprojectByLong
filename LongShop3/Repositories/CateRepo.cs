using LongShop3.Models;
using LongShop3.Repositories.IRepo;

namespace LongShop3.Repositories
{
    public class CateRepo : ICate
    {
        public List<Category> GetAllCate()
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            var listcate = context.Categories.Where(x => x.IsActive == true).ToList();
            return listcate;
        }
    }
}
