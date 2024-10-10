using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Contexts;
using InventorySystem.Data.Entities;

namespace InventorySystem.Business.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
