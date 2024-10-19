using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Contexts;
using InventorySystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Business.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public Product GetByIdWithInclude(int id)
        {
            return _context.Products.Include(e => e.Category).Include(E => E.Supplier).FirstOrDefault(I => I.Id == id);
        }

        public async Task<IEnumerable<Product>> GetLowQuantityProductsAsync(int threshold)
        {
            return await _context.Products
                .Where(p => p.StockQuantity < threshold)
                .ToListAsync();
        }
    }
}
