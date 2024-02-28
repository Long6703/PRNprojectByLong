using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public int ProductDetailId { get; set; }
        public int ColorId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual ProductDetail ProductDetail { get; set; } = null!;
    }
}
