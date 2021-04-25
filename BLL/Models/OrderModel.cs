using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Models
{
    public partial class OrderModel
    {
        public int IdOrder { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal TotalCost { get; set; }
        public string IdUserFk { get; set; }

        public OrderModel(Order o)
        {
            IdOrder = o.IdOrder;
            DateAndTime = o.DateAndTime;
            TotalCost = o.TotalCost;
            IdUserFk = o.IdUserFk;
        }
        public  OrderModel()
        {
            
        }
    }
}
