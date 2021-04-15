using System;
using System.Collections.Generic;

namespace ASPNetCore.Model
{
    public partial class OrderLine
    {
        public int IdOrderLine { get; set; }
        public int MuchOfProducts { get; set; }
        public decimal CostForBuyer { get; set; }
        public int IdOrderFk { get; set; }
        public int IdProductFk { get; set; }

        public virtual Order IdOrderFkNavigation { get; set; }
        public virtual Product IdProductFkNavigation { get; set; }
    }
}
