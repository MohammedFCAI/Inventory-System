using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Contexts;
using InventorySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Business.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
