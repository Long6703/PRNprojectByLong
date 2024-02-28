using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Discount
    {
        public int Discountid { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? DiscountPercent { get; set; }
        public string? StartAt { get; set; }
        public string? EndAt { get; set; }
        public int? ProductDetailId { get; set; }

        public virtual ProductDetail? ProductDetail { get; set; }
    }
}
