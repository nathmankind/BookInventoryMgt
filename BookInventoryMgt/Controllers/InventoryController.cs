using BookInventoryMgt.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookInventoryMgt.Controllers
{
    public class InventoryController : Controller
    {

        private InventoryDbContext _inventoryDbContext;

        public InventoryController(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/inventory")]
        public IActionResult List()
        {
            var books = _inventoryDbContext.Inventories.ToList();
            return View("List", books);
        }

        [HttpGet("/inventory/add-book")]
        public IActionResult GetAddBookToInventoryRequest()
        {
            return View("Create", new Inventory());
        }

        [HttpPost("/inventory/add-book")]
        public IActionResult AddBookToInventoryRequest(Inventory inventory)
        {
            if(ModelState.IsValid)
            {
                _inventoryDbContext.Inventories.Add(inventory);
                _inventoryDbContext.SaveChanges();
                TempData["Message"] = "Book has been added to the inventory";
                return RedirectToAction("List", "Inventory");
            }else
            return View("Create", inventory);
        }


        public IActionResult FilterFromInventory(string queryString)
        {
            if (!queryString.IsNullOrEmpty())
            {


                return View("List", "Inventory");
            }
            return RedirectToAction("List", "Inventory");
        }


        public IActionResult ExportToCsv()
        {
            var randomNo = new Random().Next();

            var _allInventoryBooks = _inventoryDbContext.Inventories.ToList();
            var csv = GenerateCsvFile(_allInventoryBooks);
            var fileName = $"Book_inventory_{randomNo}.csv";
            var fileContent = Encoding.UTF8.GetBytes(csv);
            return File(fileContent, "text/csv", fileName);
        }

        private string GenerateCsvFile  (IEnumerable<Inventory> inventory)
        {
            var csvBuilder = new StringBuilder();


            csvBuilder.AppendLine("ID,Title,Author,Genre,PublicationDate,ISBN");
            foreach (var book in inventory)
            {
                csvBuilder.AppendLine($"{book.EntryId},{book.Title},{book.Author},{book.Genre},{book.PublicationDate},{book.ISBN}");
            }
            return csvBuilder.ToString();
        }




        

    }
}
