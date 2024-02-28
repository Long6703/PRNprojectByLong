using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            Discounts = new HashSet<Discount>();
            Images = new HashSet<Image>();
            SizeColorStocks = new HashSet<SizeColorStock>();
        }

        public int ProductDetailId { get; set; }
        public string ProductName { get; set; } = null!;
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? CreateAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsSale { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<SizeColorStock> SizeColorStocks { get; set; }
    }
}
