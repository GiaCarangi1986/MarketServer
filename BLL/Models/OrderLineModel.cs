using DAL;

namespace BLL.Models
{
    public class OrderLineModel
    {
        public int IdOrderLine { get; set; }
        public int MuchOfProducts { get; set; }
        public decimal CostForBuyer { get; set; }
        public int IdOrderFk { get; set; }
        public int IdProductFk { get; set; }
        public OrderLineModel(OrderLine o)
        {
            IdOrderLine = o.IdOrderLine;
            MuchOfProducts = o.MuchOfProducts;
            CostForBuyer = o.CostForBuyer;
            IdOrderFk = o.IdOrderFk;
            IdProductFk = o.IdProductFk;
        }
        public OrderLineModel()
        {

        }
    }
}
