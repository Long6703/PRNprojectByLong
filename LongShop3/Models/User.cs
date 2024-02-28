using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            ContentAboutus = new HashSet<ContentAboutu>();
            GroupAccounts = new HashSet<GroupAccount>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public string? CreateAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ContentAboutu> ContentAboutus { get; set; }
        public virtual ICollection<GroupAccount> GroupAccounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
