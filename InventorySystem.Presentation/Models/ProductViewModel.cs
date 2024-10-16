using InventorySystem.Data.Entities;

namespace InventorySystem.Presentation.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int? SelectedCategoryId { get; set; }
    }

}
