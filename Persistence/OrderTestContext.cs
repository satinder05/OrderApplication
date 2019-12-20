using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace Persistence
{
    public partial class OrderTestContext : DbContext, IOrderDbContext
    {
        public OrderTestContext()
        {
        }

        public OrderTestContext(DbContextOptions<OrderTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //}
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");
                
                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("customer_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.CustomerOrderId).HasColumnName("order_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");
                
                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)");
            });
        }
    }
}
