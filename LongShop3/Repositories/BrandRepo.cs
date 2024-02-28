using LongShop3.Models;
using LongShop3.Repositories.IRepo;

namespace LongShop3.Repositories
{
    public class BrandRepo : IBrandRepocs
    {
        public List<Brand> GetAllBrands()
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            var listbrand = context.Brands.Where(x => x.IsActive == true).ToList();
            return listbrand;
        }
    }
}
