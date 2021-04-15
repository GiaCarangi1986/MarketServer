using System;
using System.Collections.Generic;

namespace ASPNetCore.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int IdOrder { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal TotalCost { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
