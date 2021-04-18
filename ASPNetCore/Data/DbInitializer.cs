//using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace ASPNetCore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MarketContext context)
        {
            bool created = context.Database.EnsureCreated();

            if (context.Product.Any())
            {
                return;
            }

            var posts = new Category[]
            {
                new Category { Name="замороженные продукты" }
            };
            foreach (Category p in posts)
            {
                context.Category.Add(p);
            }

            int ok;
            if (context.SaveChanges() > 0)
                ok = 5;
            int id = context.Category.Where(i => i.IdCategory > 6).FirstOrDefault().IdCategory;
                var blogs = new Product[]
            {
                new Product{Title="блинчики", IdCategoryFk=context.Category.Where(i => i.IdCategory > 6).FirstOrDefault().IdCategory, NowCost=100, ScorGodnostiO=1000 },
                new Product{Title="мороженое", IdCategoryFk=context.Category.Where(i => i.IdCategory > 6).FirstOrDefault().IdCategory, NowCost=50, ScorGodnostiO=1000 },
                new Product{Title="пельмени", IdCategoryFk=context.Category.Where(i => i.IdCategory > 6).FirstOrDefault().IdCategory, NowCost=150, ScorGodnostiO=1000 }

            };
            foreach (Product b in blogs)
            {
                context.Product.Add(b);
            }
            context.SaveChanges();
        }
    }
}
