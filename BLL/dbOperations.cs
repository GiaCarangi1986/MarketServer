using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL
{
    public class dbOperations : IDbCrud
    {
        IdbOperations db;

        public dbOperations(IdbOperations repos)
        {
            db = repos;
        }
        #region User
        public List<UserModel> GetAllUsers()
        {
            return db.Users.GetList().Select(i => new UserModel(i)).ToList();
        }
        #endregion

        #region Order
        public List<OrderModel> GetAllOrders()
        {
            return db.Orders.GetList().Select(i => new OrderModel(i)).ToList();
        }

        public int CreateOrder(OrderModel o)
        {
            db.Orders.Create(new Order() { DateAndTime = o.DateAndTime, TotalCost = o.TotalCost, IdUserFk=o.IdUserFk});
            Save();
            int id = db.Orders.GetList().Where(i=>i.DateAndTime == o.DateAndTime && i.TotalCost == o.TotalCost).First().IdOrder;
            return id;
        }

        public void UpdateOrder(OrderModel o)
        {
            Order ord = db.Orders.GetItem(o.IdOrder);
            ord.DateAndTime = o.DateAndTime;
            ord.TotalCost = o.TotalCost;
            db.Orders.Update(ord);
            Save();
        }

        public void DeleteOrder(int id)
        {
            Order ord = db.Orders.GetItem(id);
            if (ord!=null)
            {
                var allOI = GetAllOrders();
                //foreach (var item in allOI) //хз зачем эта рекурсия
                    //DeleteOrder(item.IdOrder);
                db.Orders.Delete(ord.IdOrder);
                Save();
            }
        }

        public OrderModel GetOrder(int id)
        {
            Order ord = db.Orders.GetItem(id);
            OrderModel o = null;
            if (ord != null)
                o = new OrderModel(ord);

            //OrderModel o = new OrderModel(db.Orders.GetItem(id));
            return o;
        }
        #endregion

        #region Category
        public List<CategoryModel> GetAllCategories()
        {
            return db.Categories.GetList().Select(i=> new CategoryModel(i)).ToList();
        }

        public void CreateCategory(CategoryModel s)
        {
            db.Categories.Create(new Category() { Name = s.Name });
            Save();
        }

        public void UpdateCategory(CategoryModel s)
        {
            Category st = db.Categories.GetItem(s.IdCategory);
            st.Name = s.Name;
            db.Categories.Update(st);
            Save();
        }

        public void DeleteCategory(int id)
        {
            Category st = db.Categories.GetItem(id);
            if (st != null)
            {
                db.Categories.Delete(st.IdCategory);
                Save();
            }
        }

        public CategoryModel GetCategory(int id)
        {
            CategoryModel s = new CategoryModel(db.Categories.GetItem(id));
            return s;
        }
        #endregion

        #region Product
        public List<ProductModel> GetAllProducts()
        {
            return db.Products.GetList().Select(i => new ProductModel(i)).ToList();
        }

        public ProductModel GetProduct(int id)
        {
            ProductModel cl = new ProductModel(db.Products.GetItem(id));
            return cl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public int CreateProduct(ProductModel c)
        {
            db.Products.Create(new Product() { NowCost = c.NowCost, ScorGodnostiO = c.ScorGodnostiO, Title = c.Title, IdCategoryFk = c.IdCategoryFk });
            Save();

            return db.Products.GetList().LastOrDefault().IdProduct;
        }

        public void UpdateProduct(ProductModel c)
        {
            Product cl = db.Products.GetItem(c.IdProduct);
            cl.NowCost = c.NowCost;
            cl.ScorGodnostiO = c.ScorGodnostiO;
            cl.Title = c.Title;
            cl.IdCategoryFk = c.IdCategoryFk;
            db.Products.Update(cl);
            Save();
        }
        public void DeleteProduct(int id)
        {
            Product cl = db.Products.GetItem(id);
            if (cl != null)
            {
                db.Products.Delete(cl.IdProduct);
                Save();
            }
        }

        #endregion

        #region Delivery

        public List<DeliveryModel> GetAllDeliveries()
        {
            return db.Deliveries.GetList().Select(i => new DeliveryModel(i)).ToList();
        }

        public DeliveryModel GetDelivery(int id)
        {
            DeliveryModel dv = new DeliveryModel(db.Deliveries.GetItem(id));
            return dv;
        }

        public int CreateDelivery(DeliveryModel d)
        {
            db.Deliveries.Create(new Delivery() { DateOfDelivery = d.DateOfDelivery});
            Save();
            int id = db.Deliveries.GetList().Where(i=>i.DateOfDelivery == d.DateOfDelivery).First().IdDelivery;
            return id;
        }

        public void UpdateDelivery(DeliveryModel d)
        {
            Delivery dl = db.Deliveries.GetItem(d.IdDelivery);
            dl.DateOfDelivery = d.DateOfDelivery;
          
            db.Deliveries.Update(dl);
            Save();
        }
        public void DeleteDelivery(int id)
        {
            Delivery dl = db.Deliveries.GetItem(id);
            if (dl != null)
            {
                db.Deliveries.Delete(dl.IdDelivery);
                Save();
            }
        }
        #endregion

        #region DeliveryLine

        public List<DeliveryLineModel> GetAllDeliveryLines()
        {
            return db.DeliveryLines.GetList().Select(i => new DeliveryLineModel(i)).ToList();
        }

        public void CreateDeliveryLine(DeliveryLineModel c)
        {
            db.DeliveryLines.Create(new DeliveryLine() { CountOfProduct = c.CountOfProduct, RemainingProduct = c.RemainingProduct, DateOfPreparing = c.DateOfPreparing, Debited = c.Debited,
                OwnCost=c.OwnCost, IdProductFk = c.IdProductFk, IdDeliveryFk = c.IdDeliveryFk});
            Save();
        }

        public void UpdateDeliveryLine(DeliveryLineModel c)
        {
            DeliveryLine cr = db.DeliveryLines.GetItem(c.IdDeliveryLine);
            cr.CountOfProduct = c.CountOfProduct;
            cr.RemainingProduct = c.RemainingProduct;
            cr.DateOfPreparing = c.DateOfPreparing;
            cr.Debited = c.Debited;
            cr.OwnCost = c.OwnCost;
            cr.IdProductFk = c.IdProductFk;
            cr.IdDeliveryFk = c.IdDeliveryFk;
            db.DeliveryLines.Update(cr);
            Save();
        }
        public void DeleteDeliveryLine(int id)
        {
            DeliveryLine cr = db.DeliveryLines.GetItem(id);
            if (cr != null)
            {
                db.DeliveryLines.Delete(cr.IdDeliveryLine);
                Save();
            }
        }

        public DeliveryLineModel GetDeliveryLine(int id)
        {
            DeliveryLineModel dv = new DeliveryLineModel(db.DeliveryLines.GetItem(id));
            return dv;
        }
        #endregion

        #region OrderLine
        public List<OrderLineModel> GetAllOrderLines()
        {
            return db.OrderLines.GetList().Select(i => new OrderLineModel(i)).ToList();
        }
        public List<OrderLineModel> GetOrderLines(int id)
        {
            return db.OrderLines.GetList().Select(i => new OrderLineModel(i)).Where(i => i.IdOrderLine == id).ToList();
        }
        public int CreateOrderLine(OrderLineModel c)
        {
            db.OrderLines.Create(new OrderLine() { MuchOfProducts = c.MuchOfProducts, CostForBuyer = c.CostForBuyer, IdOrderFk = c.IdOrderFk, IdProductFk = c.IdProductFk });
            Save();

            return db.OrderLines.GetList().LastOrDefault().IdOrderLine;

            //var ord = db.Orders.GetItem(c.Order_ID_FK);
            //var toc = db.TypesOfCargo.GetItem(c.TypeOfCargo_ID_FK);
            //if (ord!=null)
            //{
            //    var cust = db.DeliveryLines.GetItem(ord.Product_ID_FK);
            //    if (toc !=null && cust!=null)
            //    {
            //        double dsc = 0;
            //        if (cust.Discount != null)
            //            dsc = (double)cust.Discount;
            //        ord.Cost = ord.Cost + c.Price * toc.Coefficient / 100.0 * (100 - dsc) / 100.0;
            //        db.Orders.Update(ord);
            //        Save();
            //    }
            //}
        }

        public void UpdateOrderLine(OrderLineModel c)
        {
            OrderLine oi = db.OrderLines.GetItem(c.IdOrderLine);
            if (oi!=null)
            {
                oi.MuchOfProducts = c.MuchOfProducts;
                oi.CostForBuyer = c.CostForBuyer;
                oi.IdOrderFk = c.IdOrderFk;
                oi.IdProductFk = c.IdProductFk;
                db.OrderLines.Update(oi);

                //var ord = db.Orders.GetItem(c.Order_ID_FK);
                //var toc = db.TypesOfCargo.GetItem(c.TypeOfCargo_ID_FK);
                //if (ord != null)
                //{
                //    var cust = db.DeliveryLines.GetItem(ord.Product_ID_FK);
                //    if (toc != null && cust != null)
                //    {
                //        double dsc = 0;
                //        if (cust.Discount != null)
                //            dsc = (double)cust.Discount;
                //        ord.Cost = ord.Cost + c.Price * toc.Coefficient / 100.0 * (100 - dsc);
                //    }
                //}
                Save();
            }

            
        }
        public void DeleteOrderLine(int id)
        {
            OrderLine cr = db.OrderLines.GetItem(id);
            if (cr != null)
            {
                //var ord = db.Orders.GetItem(cr.Order_ID_FK);
                //var toc = db.TypesOfCargo.GetItem(cr.TypeOfCargo_ID_FK);
                //if (ord != null)
                //{
                //    var cust = db.DeliveryLines.GetItem(ord.Product_ID_FK);
                //    if (toc != null && cust != null)
                //    {
                //        double dsc = 0;
                //        if (cust.Discount != null)
                //            dsc = (double)cust.Discount;
                //        ord.Cost = ord.Cost - cr.Price * toc.Coefficient / 100.0 * (100 - dsc);
                //    }
                //}
                db.OrderLines.Delete(cr.IdOrderLine);
                Save();
            }
        }
        public OrderLineModel GetOrderLine(int id)
        {
            OrderLineModel dv = new OrderLineModel(db.OrderLines.GetItem(id));
            return dv;
        }
        #endregion

        public int Save()
        {
            int SaveCh = 0;
            try
            {
                SaveCh = db.Save();
            }
            catch
            {
                return 2;
            }
            if (SaveCh > 0) return 1;
            return 0;
        }

    }
}
