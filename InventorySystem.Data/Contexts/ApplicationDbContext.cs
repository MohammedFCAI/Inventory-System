using InventorySystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// After Adding fluent apis in configurations we need to uncomment next line.
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
