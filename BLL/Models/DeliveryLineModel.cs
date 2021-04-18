using DAL;
using System;

namespace BLL.Models
{

    public partial class DeliveryLineModel
    {
        public int IdDeliveryLine { get; set; }
        public int CountOfProduct { get; set; }
        public int RemainingProduct { get; set; }
        public DateTime DateOfPreparing { get; set; }
        public bool Debited { get; set; }
        public decimal OwnCost { get; set; }
        public int IdProductFk { get; set; }
        public int IdDeliveryFk { get; set; }

        public DeliveryLineModel(DeliveryLine c)
        {
            IdDeliveryLine = c.IdDeliveryLine;
            CountOfProduct = c.CountOfProduct;
            RemainingProduct = c.RemainingProduct;
            DateOfPreparing = c.DateOfPreparing;
            Debited = c.Debited;
            OwnCost = c.OwnCost;
            IdProductFk = c.IdProductFk;
            IdDeliveryFk = c.IdDeliveryFk;
        }

        public DeliveryLineModel()
        {

        }

    }
}
