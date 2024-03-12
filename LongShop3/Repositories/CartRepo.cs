using LongShop3.Models;
using LongShop3.Repositories.IRepo;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Drawing;

namespace LongShop3.Repositories
{
    public class CartRepo : ICartRepo
    {
        public bool deleteAllcartRepo(string username)
        {
            using(var context = new SHOPLONG5Context())
            {
                var query = context.Carts.Where(c => c.Username == username);
                List<Cart> listcart = query.ToList();
                foreach (var cart in listcart)
                {
                    context.Carts.Remove(cart);
                }
                context.SaveChanges();
                return true;
            }
        }

        public List<Product_Size_Color_Stock> getallCart(string username)
        {
            using (var context = new SHOPLONG5Context())
            {
                var commonIds = context.Carts.Where(x => x.Username == username).Select(x => x.CommonId).ToList();

                var query = (from scs in context.SizeColorStocks
                             join pd in context.ProductDetails on scs.ProductDetailId equals pd.ProductDetailId
                             join s in context.Sizes on scs.SizeId equals s.SizeId
                             join c in context.Colors on scs.ColorId equals c.ColorId
                             join cart in context.Carts on scs.CommonId equals cart.CommonId
                             where commonIds.Contains(scs.CommonId) && cart.Username == username
                             select new Product_Size_Color_Stock
                             {
                                 pd = pd,
                                 size = s,
                                 color = c,
                                 scs = scs,
                                 cart = cart,
                                 images = context.Images.Where(i => i.ProductDetailId == scs.ProductDetailId && i.ColorId == scs.ColorId).ToList()
                             }).ToList();
                return query;
            }
        }
    }
}
