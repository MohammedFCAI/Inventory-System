using InventorySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Business.Interfaces
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<int> CountRestockOperationsAsync();
        Task<int> CountTakeOperationsAsync();
    }
}
