using BookInventoryMgt.Models;
using System.ComponentModel.DataAnnotations;

namespace BookInventoryMgt.Entities
{
    public class Inventory
    {
     
        public int EntryId { get; set; }

        [Required(ErrorMessage ="TItle is required")]
        public string Title { get; set; }


        [Required(ErrorMessage ="Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publication date is required")]
        [NoFutureDate(ErrorMessage ="No future date allowed")]
        public DateTime PublicationDate { get; set; }


        //978-1-60309-442-9   ISBN Format : "X-XXX-XXXXX-X" || "978-X-XXX-XXXXX-X" 
        [Required(ErrorMessage ="ISBN is required")] 
        [RegularExpression(@"^(?:\d{1}-\d{3}-\d{5}-[\dX]|978-\d{1}-\d{3}-\d{5}-\d)$", ErrorMessage = "Enter a valid ISBN number in format 978-X-XXX-XXXXX-X or X-XXX-XXXXX-X")]
        public string ISBN { get; set; }


        //[Required(ErrorMessage = "Genre is required")]
       // public int GenreId { get; set; }


        //public Genre? Genre { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

    }
}
