using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Contexts;

namespace InventorySystem.Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            Products = new ProductRepository(context);
            Suppliers = new SupplierRepository(context);
        }

        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
