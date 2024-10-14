using InventorySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Business.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalStocks { get; set; }
        public int TotalProducts { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalCategories { get; set; }
        public IEnumerable<Stock> AllStocks { get; set; }
        public IEnumerable<Product> AllProducts { get; set; }
        public List<int> StockQuantities { get; set; }
        public List<string> StockDates { get; set; }
        public List<string> ProductNames { get; set; }
        public List<int> ProductQuantities { get; set; }
    }

}
