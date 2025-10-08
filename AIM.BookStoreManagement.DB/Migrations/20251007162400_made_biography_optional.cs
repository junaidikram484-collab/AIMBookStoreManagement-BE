using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIM.BookStoreManagement.DB.Migrations
{
    public partial class made_biography_optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("25920ac5-99d1-47a8-b832-7dbef8a6e7d6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4aab8e52-4ead-4612-b913-486ee3aa9e87"));

            migrationBuilder.AlterColumn<string>(
                name: "BioGraphy",
                table: "Authors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("625b97d7-0413-4fb2-9b76-cb5b2531cfc0"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), 0, "A Wizard of Earthsea", 1968 },
                    { new Guid("801c6b02-efda-48a7-9df7-badf28f091f2"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), 0, "Guards! Guards!", 1989 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("625b97d7-0413-4fb2-9b76-cb5b2531cfc0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("801c6b02-efda-48a7-9df7-badf28f091f2"));

            migrationBuilder.AlterColumn<string>(
                name: "BioGraphy",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("25920ac5-99d1-47a8-b832-7dbef8a6e7d6"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), 0, "Guards! Guards!", 1989 },
                    { new Guid("4aab8e52-4ead-4612-b913-486ee3aa9e87"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), 0, "A Wizard of Earthsea", 1968 }
                });
        }
    }
}
