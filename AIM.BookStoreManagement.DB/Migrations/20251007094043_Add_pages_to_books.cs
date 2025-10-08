using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIM.BookStoreManagement.DB.Migrations
{
    public partial class Add_pages_to_books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("17729767-93d2-4a29-a964-e56eedc98814"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("70a4fab3-605c-4f8d-a665-006b22374f91"));

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("25920ac5-99d1-47a8-b832-7dbef8a6e7d6"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), 0, "Guards! Guards!", 1989 },
                    { new Guid("4aab8e52-4ead-4612-b913-486ee3aa9e87"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), 0, "A Wizard of Earthsea", 1968 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("25920ac5-99d1-47a8-b832-7dbef8a6e7d6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4aab8e52-4ead-4612-b913-486ee3aa9e87"));

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("17729767-93d2-4a29-a964-e56eedc98814"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), "A Wizard of Earthsea", 1968 },
                    { new Guid("70a4fab3-605c-4f8d-a665-006b22374f91"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), "Guards! Guards!", 1989 }
                });
        }
    }
}
