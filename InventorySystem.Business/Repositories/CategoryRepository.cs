using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Contexts;
using InventorySystem.Data.Entities;

namespace InventorySystem.Business.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
