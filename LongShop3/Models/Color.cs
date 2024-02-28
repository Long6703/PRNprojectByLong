using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Color
    {
        public Color()
        {
            Images = new HashSet<Image>();
            SizeColorStocks = new HashSet<SizeColorStock>();
        }

        public int ColorId { get; set; }
        public string? ColorName { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<SizeColorStock> SizeColorStocks { get; set; }
    }
}
