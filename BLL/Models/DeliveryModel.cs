using System;
using DAL;

namespace BLL.Models
{
    public class DeliveryModel
    {
        public int IdDelivery { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public DeliveryModel(Delivery d)
        {
            IdDelivery = d.IdDelivery;
            DateOfDelivery = d.DateOfDelivery;
        }

        public DeliveryModel() { }
    }
}
