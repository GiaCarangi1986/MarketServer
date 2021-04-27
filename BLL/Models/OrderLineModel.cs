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
        public string NameProduct { get; set; }
        public int CountMax { get; set; }
        public OrderLineModel(OrderLine o)
        {
            if (o!=null)
            {
                IdOrderLine = o.IdOrderLine;
                MuchOfProducts = o.MuchOfProducts;
                CostForBuyer = o.CostForBuyer;
                IdOrderFk = o.IdOrderFk;
                IdProductFk = o.IdProductFk;

                NameProduct = o.IdProductFkNavigation.Title;
            }
        }
        public OrderLineModel()
        {

        }
    }
}
