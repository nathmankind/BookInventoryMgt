using Microsoft.EntityFrameworkCore;

namespace BookInventoryMgt.Entities
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Set EntryId Data to be the PrimaryKey
            modelBuilder.Entity<Inventory>().HasKey(b => b.EntryId);

            // Set ISBN Data to unique
            modelBuilder.Entity<Inventory>().HasIndex(b => b.ISBN).IsUnique();


            //Seeding some data here
            modelBuilder.Entity<Inventory>().HasData(

                new Inventory()
                {
                    EntryId = 1,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    PublicationDate = DateTime.Today,
                    ISBN = "978-0-06-112008-4"
                },
                new Inventory()
                {
                    EntryId = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    PublicationDate = DateTime.Today,
                    ISBN = "978-0-452-28423-4"
                },
                new Inventory()
                {
                    EntryId = 3,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    PublicationDate = DateTime.Today,
                    ISBN = "978-0-19-953556-9"
                },
                new Inventory()
                {
                    EntryId = 4,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Tragedy",
                    PublicationDate = DateTime.Today,
                    ISBN = "978-0-7432-7356-5"
                },
                new Inventory()
                {
                    EntryId = 5,
                    Title = "The Shining",
                    Author = "Stephen King",
                    Genre = "Horror",
                    PublicationDate = DateTime.Today,
                    ISBN = "978-0-385-12167-1"
                }
            );
        }
    }
}