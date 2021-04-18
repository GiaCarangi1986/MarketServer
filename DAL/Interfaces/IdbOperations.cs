  namespace DAL.Interfaces
{
    public interface IdbOperations
    {
        IRepository<Delivery> Deliveries { get; }
        IRepository<Order> Orders { get; }
        IRepository<Category> Categories { get; }
        IRepository<DeliveryLine> DeliveryLines { get; }
        IUsersRepository<User> Users { get; }
        IRepository<OrderLine> OrderLines { get; }
        IRepository<Product> Products { get; }
        int Save();
    }
}
