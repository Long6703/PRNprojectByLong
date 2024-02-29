using LongShop3.Models;
namespace LongShop3.Repositories.IRepo
{
    public interface IBrandRepocs
    {
        List<Brand> GetAllBrands();

        public void createBrands(Brand brand);

        public Brand getBrandsByID(int ID);
        List<Brand> GetAllBrandsForAdmin();
        void UpdateBrandRepo(Brand brand);
    }
}
