using System;
using System.Collections.Generic;

namespace ASPNetCore.Model
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
