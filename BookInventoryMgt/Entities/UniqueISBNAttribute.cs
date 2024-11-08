using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookInventoryMgt.Entities
{
    public class UniqueISBNAttribute:ValidationAttribute
    {
        private readonly Type _dbContextType;

        public UniqueISBNAttribute(Type dbContextType)
        {
            _dbContextType = dbContextType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           

            var dbContext = (DbContext)validationContext.GetService(_dbContextType);
            var ISBN = value.ToString();

            var duplicate = dbContext.Set<Inventory>().Any(n => n.ISBN == ISBN);
            if (duplicate)
            {
                return new ValidationResult($"The ISBN '{ISBN}' is already in use.");
            }

            return ValidationResult.Success;
        }
    }

}
