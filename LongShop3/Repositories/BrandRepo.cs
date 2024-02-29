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

        public void createBrands(Brand brand)
        {
            SHOPLONG5Context ctx = new SHOPLONG5Context();
            ctx.Brands.Add(brand);
            ctx.SaveChanges();
        }

        public Brand getBrandsByID(int ID)
        {
            SHOPLONG5Context ctx = new SHOPLONG5Context();
            Brand brand = ctx.Brands.FirstOrDefault(x => x.BrandId == ID);
            return brand;

        }

        public List<Brand> GetAllBrandsForAdmin()
        {
            SHOPLONG5Context context = new SHOPLONG5Context();
            var listbrand = context.Brands.ToList();
            return listbrand;
        }

        public void UpdateBrandRepo(Brand brand)
        {
            using (var context = new SHOPLONG5Context())
            {
                Brand old = context.Brands.FirstOrDefault(x => x.BrandId == brand.BrandId);

                if (old != null)
                {
                    old.BrandName = brand.BrandName;
                    old.IsActive = brand.IsActive;
                    var productlist = context.ProductDetails.Where(x => x.BrandId == old.BrandId).ToList();
                    if(old.IsActive == false)
                    {
                        foreach (var product in productlist)
                        {
                            product.IsActive = false;
                        }
                    }
                    if(old.IsActive == true)
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
}
