using LongShop3.Models;
using LongShop3.Repositories.IRepo;

namespace LongShop3.Repositories
{
    public class CateRepo : ICate
    {
        public void AddCate(Category cate)
        {
            SHOPLONG5Context sHOPLONG5Context = new SHOPLONG5Context();
            sHOPLONG5Context.Categories.Add(cate);
            sHOPLONG5Context.SaveChanges();
        }

        public List<Category> GetAllCate()
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            var listcate = context.Categories.Where(x => x.IsActive == true).ToList();
            return listcate;
        }

        public List<Category> GetAllCateForAdmin()
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            var listcate = context.Categories.ToList();
            return listcate;
        }

        public Category GetCateByID(int id)
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            return context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public void UpdateCate(Category cate)
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            Category old = context.Categories.FirstOrDefault(x => x.CategoryId == cate.CategoryId);
            if(old != null)
            {
                old.CategoryName = cate.CategoryName;
                old.IsActive = cate.IsActive;
                var productlist = context.ProductDetails.Where(x => x.CategoryId == old.CategoryId).ToList();
                if (old.IsActive == false)
                {
                    foreach (var product in productlist)
                    {
                        product.IsActive = false;
                    }
                }
                if (old.IsActive == true)
                {
                    foreach (var product in productlist)
                    {
                        product.IsActive = true;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
