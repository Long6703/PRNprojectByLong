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

        public void AddBrand(Brand brand)
        {
            _brands.createBrands(brand);
        }

        public List<Brand> GetBrands()
        {
            return _brands.GetAllBrands();
        }

        public Brand getBrandsByID(int ID)
        {
            return _brands.getBrandsByID(ID);
        }

        public List<Brand> GetBrandsForAdmin()
        {
            return _brands.GetAllBrandsForAdmin();
        }

        public void UpdateBrand(Brand brand)
        {
             _brands.UpdateBrandRepo(brand);
        }
    }
}
