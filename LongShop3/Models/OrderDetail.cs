using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class OrderDetail
    {
        public int OrderdetailId { get; set; }
        public int CommonId { get; set; }
        public int Amount { get; set; }
        public decimal? TotalUnitPrice { get; set; }
        public int Orderid { get; set; }

        public virtual SizeColorStock Common { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
