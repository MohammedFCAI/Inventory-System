using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.ViewModels
{
    public class CreateSupplierViewModel
    {
        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(200, ErrorMessage = "Contact info cannot be longer than 200 characters.")]
        [Display(Name = "Contact Info.")]
        public string ContactInfo { get; set; }
    }
}
