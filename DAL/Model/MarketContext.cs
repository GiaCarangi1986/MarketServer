using System;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNetCore.Model
{
    public partial class MarketContext : IdentityDbContext<User>
    {
        public MarketContext()
        {
        }

        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryLine> DeliveryLine { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        //public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2C576DR\\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK_Categoria");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.IdDelivery)
                    .HasName("PK_Postavka");

                entity.Property(e => e.IdDelivery).HasColumnName("id_delivery");

                entity.Property(e => e.DateOfDelivery)
                    .HasColumnName("date_of_delivery")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DeliveryLine>(entity =>
            {
                entity.HasKey(e => e.IdDeliveryLine)
                    .HasName("PK_Line_of_postavka");

                entity.ToTable("Delivery_line");

                entity.Property(e => e.IdDeliveryLine).HasColumnName("id_delivery_line");

                entity.Property(e => e.CountOfProduct).HasColumnName("count_of_product");

                entity.Property(e => e.DateOfPreparing)
                    .HasColumnName("date_of_preparing")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debited).HasColumnName("debited");

                entity.Property(e => e.IdDeliveryFk).HasColumnName("id_delivery_FK");

                entity.Property(e => e.IdProductFk).HasColumnName("id_product_FK");

                entity.Property(e => e.OwnCost)
                    .HasColumnName("own_cost")
                    .HasColumnType("money");

                entity.Property(e => e.RemainingProduct).HasColumnName("remaining_product");

                entity.HasOne(d => d.IdDeliveryFkNavigation)
                    .WithMany(p => p.DeliveryLine)
                    .HasForeignKey(d => d.IdDeliveryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_line_Delivery");

                entity.HasOne(d => d.IdProductFkNavigation)
                    .WithMany(p => p.DeliveryLine)
                    .HasForeignKey(d => d.IdProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_line_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_Check");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.DateAndTime)
                    .HasColumnName("date_and_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalCost)
                    .HasColumnName("total_cost")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.IdOrderLine)
                    .HasName("PK_Line_of_check");

                entity.ToTable("Order_line");

                entity.Property(e => e.IdOrderLine).HasColumnName("id_order_line");

                entity.Property(e => e.CostForBuyer)
                    .HasColumnName("cost_for_buyer")
                    .HasColumnType("money");

                entity.Property(e => e.IdOrderFk).HasColumnName("id_order_FK");

                entity.Property(e => e.IdProductFk).HasColumnName("id_product_FK");

                entity.Property(e => e.MuchOfProducts).HasColumnName("much_of_products");

                entity.HasOne(d => d.IdOrderFkNavigation)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.IdOrderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_line_Order");

                entity.HasOne(d => d.IdProductFkNavigation)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.IdProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_line_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdCategoryFk).HasColumnName("id_category_FK");

                entity.Property(e => e.NowCost)
                    .HasColumnName("now_cost")
                    .HasColumnType("money");

                entity.Property(e => e.ScorGodnostiO).HasColumnName("scor_godnosti_O");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryFkNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCategoryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            /*modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });*/
        }
    }
}
