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




            //if (value is DateTime)
            //{
            //    DateTime dateTimeCheck = (DateTime)value;

            //    dateTimeCheck = dateTimeCheck.AddYears(_minAge);

            //    if (dateTimeCheck <= DateTime.Today)
            //    {
            //        return ValidationResult.Success;
            //    }
            //}
            //return new ValidationResult(GetMsg(validationContext.DisplayName));
            ////return base.IsValid(value, validationContext)



        }
    }
}
