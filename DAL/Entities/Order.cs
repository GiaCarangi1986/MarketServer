namespace DAL
{
    using System;
    using System.Collections.Generic;
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int IdOrder { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal TotalCost { get; set; }
        public string IdUserFk { get; set; }

        public virtual User IdUserFkNavigation { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
