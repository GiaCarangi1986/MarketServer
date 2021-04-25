using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private MarketContext db;

        public ProductRepository(MarketContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Product> GetList()
        {
            //return db.Product.ToList();
            List<Product> nl = db.Product.Include(s => s.IdCategoryFkNavigation).Include(cl => cl.OrderLine).Include(dl => dl.DeliveryLine).ToList(); // убери!
            return nl;
        }

        public Product GetItem(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product item)
        {
            db.Product.Add(item);
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product item = db.Product.Find(id);
            if (item != null)
                db.Product.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
