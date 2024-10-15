using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfrimPassword { get; set; }
    }
}
