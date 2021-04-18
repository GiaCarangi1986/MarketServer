using DAL;

namespace BLL.Models
{

    public partial class ProductModel
    {
        public int IdProduct { get; set; }
        public decimal NowCost { get; set; }
        public int? ScorGodnostiO { get; set; }
        public string Title { get; set; }
        public int IdCategoryFk { get; set; }

        public ProductModel(Product s)
        {
            IdProduct = s.IdProduct;
            NowCost = s.NowCost;
            ScorGodnostiO = s.ScorGodnostiO;
            Title = s.Title;
            IdCategoryFk = s.IdCategoryFk;
        }

        public ProductModel() { }
    }
}
