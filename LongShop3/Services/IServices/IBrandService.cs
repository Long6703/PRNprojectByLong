using LongShop3.Models;

namespace LongShop3.Services.IServices
{
    public interface IBrandService
    {
        List<Brand> GetBrands();

        void AddBrand(Brand brand);

        public Brand getBrandsByID(int ID);

        List<Brand> GetBrandsForAdmin();

        void UpdateBrand(Brand brand);

    }
}
