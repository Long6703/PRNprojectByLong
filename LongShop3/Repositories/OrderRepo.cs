using LongShop3.Models;
using LongShop3.Repositories.IRepo;

namespace LongShop3.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        public Product_Size_Color_Stock getProductinfor(int commonId)
        {
            using (var context = new SHOPLONG5Context())
            {

                var query = (from scs in context.SizeColorStocks
                             join pd in context.ProductDetails on scs.ProductDetailId equals pd.ProductDetailId
                             join s in context.Sizes on scs.SizeId equals s.SizeId
                             join c in context.Colors on scs.ColorId equals c.ColorId
                             where scs.CommonId == commonId
                             select new Product_Size_Color_Stock
                             {
                                 pd = pd,
                                 size = s,
                                 color = c,
                                 scs = scs,
                                 images = context.Images.Where(i => i.ProductDetailId == scs.ProductDetailId && i.ColorId == scs.ColorId).ToList()
                             });
                return query.FirstOrDefault();
            }
        }

        public void CompleteOrder(Order order)
        {

        }
    }
}
