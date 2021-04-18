using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderLineRepository : IRepository<OrderLine>
    {
        private MarketContext db;

        public OrderLineRepository(MarketContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<OrderLine> GetList()
        {
            return db.OrderLine.ToList();
        }

        public OrderLine GetItem(int id)
        {
            return db.OrderLine.Find(id);
        }

        public void Create(OrderLine item)
        {
            db.OrderLine.Add(item);
        }

        public void Update(OrderLine item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderLine item = db.OrderLine.Find(id);
            if (item != null)
                db.OrderLine.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
