using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class ContentAboutu
    {
        public int Contentid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CreateBy { get; set; }

        public virtual User? CreateByNavigation { get; set; }
    }
}
