using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        #region GetAll
        List<OrderModel> GetAllOrders();
        List<ProductModel> GetAllProducts();
        List<DeliveryLineModel> GetAllDeliveryLines();
        List<CategoryModel> GetAllCategories();
        List<DeliveryModel> GetAllDeliveries();
        List<OrderLineModel> GetAllOrderLines();
        #endregion

        #region GetOne
        OrderModel GetOrder(int id);
        ProductModel GetProduct(int id);
        DeliveryLineModel GetDeliveryLine(int id);
        CategoryModel GetCategory(int id);
        DeliveryModel GetDelivery(int id);
        OrderLineModel GetOrderLine(int id);
        #endregion

        #region CRUDOrder
        int CreateOrder(OrderModel o);
        void UpdateOrder(OrderModel o);
        void DeleteOrder(int id);
        #endregion

        #region CRUDDeliveryLine
        void CreateDeliveryLine(DeliveryLineModel c);
        void UpdateDeliveryLine(DeliveryLineModel c);
        void DeleteDeliveryLine(int id);
        #endregion

        #region CRUDCategory
        void CreateCategory(CategoryModel c);
        void UpdateCategory(CategoryModel c);
        void DeleteCategory(int id);
        #endregion

        #region CRUDProduct
        int CreateProduct(ProductModel s);
        void UpdateProduct(ProductModel s);
        void DeleteProduct(int id);
        #endregion

        #region CRUDDelivery
        int CreateDelivery(DeliveryModel s);
        void UpdateDelivery(DeliveryModel s);
        void DeleteDelivery(int id);
        #endregion

        #region CRUDOrderLine
        int CreateOrderLine(OrderLineModel c);
        void UpdateOrderLine(OrderLineModel c);
        void DeleteOrderLine(int id);
        #endregion

        int Save();
    }
}
