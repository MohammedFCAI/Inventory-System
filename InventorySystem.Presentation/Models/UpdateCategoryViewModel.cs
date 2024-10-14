using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.Models
{
    public class UpdateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
