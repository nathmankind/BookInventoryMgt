using System.ComponentModel.DataAnnotations;

namespace BookInventoryMgt.Entities
{
    public class NoFutureDateAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult("The date cannot be in the future.");
                }
            }

            return ValidationResult.Success;



        }
    }
}
