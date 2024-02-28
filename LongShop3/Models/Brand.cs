using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Brand
    {
        public Brand()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
