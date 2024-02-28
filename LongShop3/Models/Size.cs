using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Size
    {
        public Size()
        {
            SizeColorStocks = new HashSet<SizeColorStock>();
        }

        public int SizeId { get; set; }
        public string? SizeName { get; set; }

        public virtual ICollection<SizeColorStock> SizeColorStocks { get; set; }
    }
}
