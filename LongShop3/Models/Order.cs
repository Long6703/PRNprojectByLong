using System;
using System.Collections.Generic;

namespace LongShop3.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Orderid { get; set; }
        public string Username { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string StatusOrder { get; set; } = null!;
        public string OrderDate { get; set; } = null!;

        public virtual User UsernameNavigation { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
