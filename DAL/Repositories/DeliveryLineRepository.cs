using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DeliveryLineRepository : IRepository<DeliveryLine>
    {
        private MarketContext db;

        public DeliveryLineRepository(MarketContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<DeliveryLine> GetList()
        {
            //return db.DeliveryLine.ToList();
            List<DeliveryLine> nl = db.DeliveryLine.Include(s => s.IdDeliveryFkNavigation).Include(cl => cl.IdProductFkNavigation).ToList();
            return nl;
        }

        public DeliveryLine GetItem(int id)
        {
            return db.DeliveryLine.Find(id);
        }

        public void Create(DeliveryLine item)
        {
            db.DeliveryLine.Add(item);
        }

        public void Update(DeliveryLine item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DeliveryLine item = db.DeliveryLine.Find(id);
            if (item != null)
                db.DeliveryLine.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
