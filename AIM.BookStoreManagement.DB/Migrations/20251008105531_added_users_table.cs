using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIM.BookStoreManagement.DB.Migrations
{
    public partial class added_users_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("625b97d7-0413-4fb2-9b76-cb5b2531cfc0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("801c6b02-efda-48a7-9df7-badf28f091f2"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("3dcde1df-5dee-4336-a7f3-55e5ae6d0cf6"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), 0, "Guards! Guards!", 1989 },
                    { new Guid("7dd243f3-f563-47b3-8dd9-0fb26e5bd763"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), 0, "A Wizard of Earthsea", 1968 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastLogin", "Name", "Password", "Username" },
                values: new object[] { new Guid("35883abd-cf2e-4c78-8593-b102e5e9fe0f"), null, "admin", "Test@321", "aim_admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3dcde1df-5dee-4336-a7f3-55e5ae6d0cf6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7dd243f3-f563-47b3-8dd9-0fb26e5bd763"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Pages", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("625b97d7-0413-4fb2-9b76-cb5b2531cfc0"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), 0, "A Wizard of Earthsea", 1968 },
                    { new Guid("801c6b02-efda-48a7-9df7-badf28f091f2"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), 0, "Guards! Guards!", 1989 }
                });
        }
    }
}
