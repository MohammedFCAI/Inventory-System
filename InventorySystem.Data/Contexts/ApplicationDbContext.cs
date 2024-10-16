using InventorySystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// After Adding fluent apis in configurations we need to uncomment next line.
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SupplierCategory>()
    .HasKey(sc => new { sc.SupplierId, sc.CategoryId });

            modelBuilder.Entity<SupplierCategory>()
                .HasOne(sc => sc.Supplier)
                .WithMany(s => s.SupplierCategories)
                .HasForeignKey(sc => sc.SupplierId);

            modelBuilder.Entity<SupplierCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.SupplierCategories)
                .HasForeignKey(sc => sc.CategoryId);
            // M-M relationship between supplier and category
        }
    }
}
