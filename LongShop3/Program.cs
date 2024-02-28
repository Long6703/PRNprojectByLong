using LongShop3.Repositories.IRepo;
using LongShop3.Repositories;
using LongShop3.Services.IServices;
using LongShop3.Services;

namespace LongShop3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSingleton<IBrandRepocs, BrandRepo>();
            builder.Services.AddSingleton<IBrandService, BrandServies>();

            builder.Services.AddSingleton<ICate, CateRepo>();
            builder.Services.AddSingleton<ICateServices, CateServices>();

            builder.Services.AddSingleton<IProductRepo, ProductRepo>();
            builder.Services.AddSingleton<IProductServicecs, ProductService>();

            builder.Services.AddSingleton<IUserRepo, UserRepo>();
            builder.Services.AddSingleton<IUserServices, UserServices>();
            
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}