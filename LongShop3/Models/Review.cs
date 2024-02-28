using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string? Username { get; set; }
        public int? CommonId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public string? ReviewDate { get; set; }

        public virtual SizeColorStock? Common { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
