using System;
using System.Collections.Generic;

namespace ASPNetCore.Model
{
    public partial class Delivery
    {
        public Delivery()
        {
            DeliveryLine = new HashSet<DeliveryLine>();
        }

        public int IdDelivery { get; set; }
        public DateTime DateOfDelivery { get; set; }

        public virtual ICollection<DeliveryLine> DeliveryLine { get; set; }
    }
}
