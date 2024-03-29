﻿using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string Username { get; set; } = null!;
        public string AddressName { get; set; } = null!;

        public virtual User UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
