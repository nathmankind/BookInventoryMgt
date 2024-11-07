using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookInventoryMgt.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.EntryId);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "EntryId", "Author", "Genre", "ISBN", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", "Fiction", "978-0-06-112008-4", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "To Kill a Mockingbird" },
                    { 2, "George Orwell", "Dystopian", "978-0-452-28423-4", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "1984" },
                    { 3, "Jane Austen", "Romance", "978-0-19-953556-9", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "Pride and Prejudice" },
                    { 4, "F. Scott Fitzgerald", "Tragedy", "978-0-7432-7356-5", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "The Great Gatsby" },
                    { 5, "Stephen King", "Horror", "978-0-385-12167-1", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "The Shining" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ISBN",
                table: "Inventories",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
