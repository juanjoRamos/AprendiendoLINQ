using AprendiendoLINQ.Dto;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoLINQ.Dbcontext
{
    public class NorthwingContext : DbContext
    {
        public DbSet<Category> TableCategories { get; set; } = null!;
        public DbSet<Customer> TableCustomers { get; set; } = null!;
        public DbSet<Order> TableOrders { get; set; } = null!;
        public DbSet<Product> TableProducts { get; set; } = null!;
        public DbSet<Supplier> TableSuppliers { get; set; } = null!;
        public DbSet<OrderDetails> TableOrderDetails { get; set; } = null!;

        public NorthwingContext(DbContextOptions<NorthwingContext> options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("customers");


            modelBuilder.Entity<Order>().ToTable("orders");

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderDetails>()
                .ToTable("orderdetails");

            modelBuilder.Entity<Category>()
                .ToTable("categories");

            base.OnModelCreating(modelBuilder);
        }

    }
}
