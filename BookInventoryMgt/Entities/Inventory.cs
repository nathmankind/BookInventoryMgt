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

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }


        [Required(ErrorMessage = "Publication date is required")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage ="ISBN is required")]
        [RegularExpression(@"^(?:\d{9}[0-9X]|97[89]\d{10})$", ErrorMessage ="ISBN Number has to be either 10 digits or 13 digits")]
        public string ISBN { get; set; }

    }
}
