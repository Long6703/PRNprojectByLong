using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupAccounts = new HashSet<GroupAccount>();
            GroupFeatures = new HashSet<GroupFeature>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;

        public virtual ICollection<GroupAccount> GroupAccounts { get; set; }
        public virtual ICollection<GroupFeature> GroupFeatures { get; set; }
    }
}
