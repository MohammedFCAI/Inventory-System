using Azure;
using InventorySystem.Data.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Data.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ApplicationUser")]
        public string AdminID { get; set; }
        public DateTime Date { get; set; }
        public Enum.Operation Operation { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public ApplicationUser Admin { get; set; }
        public Product Product { get; set; }

    }
}
