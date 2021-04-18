using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private MarketContext db;

        public OrderRepository(MarketContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> GetList()
        {
            /*List<Order> nl = db.Order.Include(s => s.Status).Include(cl=> cl.Customer).Include(cour=>cour.Courier).ToList(); // убери!
            return nl;*/
            return db.Order.ToList();
        }

        public Order GetItem(int id)
        {
            /*var item = db.Order.Find(id);
            if (item != null)
            {
                item.Status = db.Status.Find(item.Status_ID_FK);
                item.OrderItems = db.OrderItem.Where(i => i.Order_ID_FK == id).ToList();
            }
            return item;*/
            return db.Order.Find(id);
        }

        public void Create(Order item)
        {
            db.Order.Add(item);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order item = db.Order.Find(id);
            if (item != null)
                db.Order.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
