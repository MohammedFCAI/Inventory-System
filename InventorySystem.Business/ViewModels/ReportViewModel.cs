using InventorySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Business.ViewModels
{
    public class ReportViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int TotalRestockOperations { get; set; }
        public int TotalTakeOperations { get; set; }
        public IEnumerable<Stock> AllStocks { get; set; }
        public IEnumerable<Product> AllProducts { get; set; }
        public IEnumerable<Supplier> AllSuppliers { get; set; }
        public IEnumerable<Category> AllCategories { get; set; }
    }

}
