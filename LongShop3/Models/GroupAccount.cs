using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class GroupAccount
    {
        public int GroupId { get; set; }
        public string Username { get; set; } = null!;
        public string? Createat { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
