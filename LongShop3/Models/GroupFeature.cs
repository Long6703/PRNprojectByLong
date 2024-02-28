using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class GroupFeature
    {
        public int GroupId { get; set; }
        public int FeatureId { get; set; }
        public string? Createat { get; set; }

        public virtual Feature Feature { get; set; } = null!;
        public virtual Group Group { get; set; } = null!;
    }
}
