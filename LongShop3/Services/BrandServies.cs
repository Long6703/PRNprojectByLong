using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using LongShop3.Services.IServices;

namespace LongShop3.Services
{
    public class BrandServies : IBrandService
    {
        private readonly IBrandRepocs _brands;

        public BrandServies(IBrandRepocs brandRepocs)
        {
            _brands = brandRepocs;
        }

        public List<Brand> GetBrands()
        {
            return _brands.GetAllBrands();
        }
    }
}
