using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class SizeColorStock
    {
        public SizeColorStock()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
            Reviews = new HashSet<Review>();
        }

        public int CommonId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public int? QuantityStock { get; set; }
        public int? ProductDetailId { get; set; }

        public virtual Color? Color { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public virtual Size? Size { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
