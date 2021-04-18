using DAL;

namespace BLL.Models
{

    public partial class CategoryModel
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public CategoryModel(Category c)
        {
            IdCategory = c.IdCategory;
            Name = c.Name;
        }
        public CategoryModel() { }
    }
}
