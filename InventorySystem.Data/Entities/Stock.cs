using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Data.Entities
{
    public class Stock
    {
        // Properties
        public int StockId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public Enum.Operation Operation { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public ApplicationUser? Admin { get; set; }
        [ForeignKey("ApplicationUser")]
        public string? AdminID { get; set; }
        public Product Product { get; set; }
        public bool ToInventory { get; set; }
        public decimal Price { get; set; }

    }
}
