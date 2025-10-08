using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIM.BookStoreManagement.DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BioGraphy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    YearPublished = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BioGraphy", "Name" },
                values: new object[,]
                {
                    { new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), "The late, great fantasy author.", "Terry Pratchett" },
                    { new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), "Master of social science fiction.", "Ursula K. Le Guin" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Title", "YearPublished" },
                values: new object[,]
                {
                    { new Guid("17729767-93d2-4a29-a964-e56eedc98814"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4"), "A Wizard of Earthsea", 1968 },
                    { new Guid("70a4fab3-605c-4f8d-a665-006b22374f91"), new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3"), "Guards! Guards!", 1989 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
