using InventorySystem.Data.Contexts;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.Validations
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var categoryName = value as string;

            if (context.Categories.Any(d => d.Name.ToLower() == categoryName.ToLower()))
            {
                return new ValidationResult(ErrorMessage ?? "Category name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
