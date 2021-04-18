namespace DAL
{
    using System;
    using System.Collections.Generic;
    public partial class DeliveryLine
    {
        public int IdDeliveryLine { get; set; }
        public int CountOfProduct { get; set; }
        public int RemainingProduct { get; set; }
        public DateTime DateOfPreparing { get; set; }
        public bool Debited { get; set; }
        public decimal OwnCost { get; set; }
        public int IdProductFk { get; set; }
        public int IdDeliveryFk { get; set; }

        public virtual Delivery IdDeliveryFkNavigation { get; set; }
        public virtual Product IdProductFkNavigation { get; set; }
    }
}
