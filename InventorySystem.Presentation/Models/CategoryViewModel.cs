using InventorySystem.Presentation.Validations;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.Models
{
    public class CategoryViewModel
    {
        [Required]
        [Unique]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
