using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CreateAt { get; set; }
        public bool? IsActive { get; set; }
        public string? CateUrl { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
