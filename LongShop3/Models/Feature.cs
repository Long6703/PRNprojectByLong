using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Feature
    {
        public Feature()
        {
            GroupFeatures = new HashSet<GroupFeature>();
        }

        public int FeatureId { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<GroupFeature> GroupFeatures { get; set; }
    }
}
