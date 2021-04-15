using System;
using System.Collections.Generic;

namespace ASPNetCore.Model
{
    public partial class Product
    {
        public Product()
        {
            DeliveryLine = new HashSet<DeliveryLine>();
            OrderLine = new HashSet<OrderLine>();
        }

        public int IdProduct { get; set; }
        public decimal NowCost { get; set; }
        public int? ScorGodnostiO { get; set; }
        public string Title { get; set; }
        public int IdCategoryFk { get; set; }

        public virtual Category IdCategoryFkNavigation { get; set; }
        public virtual ICollection<DeliveryLine> DeliveryLine { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
