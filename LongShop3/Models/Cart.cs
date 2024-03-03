using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Cart
    {
        public int Cartid { get; set; }
        public int CommonId { get; set; }
        public string? CreateAt { get; set; }
        public string Username { get; set; } = null!;
        public int Amount { get; set; }

        public virtual SizeColorStock Common { get; set; } = null!;
        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
