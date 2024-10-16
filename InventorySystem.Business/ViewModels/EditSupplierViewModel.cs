using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.ViewModels
{
    public class EditSupplierViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact info is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string ContactInfo { get; set; }
    }
}
