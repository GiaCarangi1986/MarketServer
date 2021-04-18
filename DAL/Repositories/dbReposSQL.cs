using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class dbReposSQL : IdbOperations
    {
        private MarketContext db;
        private DeliveryRepository deliveryRepository;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        private DeliveryLineRepository deliveryLineRepository;
        private UserRepository userRepository;
        private OrderLineRepository orderLineRepository;
        private CategoryRepository categoryRepository;
         
        public dbReposSQL(DbContextOptions<MarketContext> options)
        {
            db = new MarketContext(options);
        }


        public IRepository<Delivery> Deliveries
        {
            get
            {
                if (deliveryRepository == null)
                    deliveryRepository = new DeliveryRepository(db);
                return deliveryRepository;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<DeliveryLine> DeliveryLines
        {
            get
            {
                if (deliveryLineRepository == null)
                    deliveryLineRepository = new DeliveryLineRepository(db);
                return deliveryLineRepository;
            }
        }
        public IRepository<OrderLine> OrderLines
        {
            get
            {
                if (orderLineRepository == null)
                    orderLineRepository = new OrderLineRepository(db);
                return orderLineRepository;
            }
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }
        public IUsersRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }


        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
