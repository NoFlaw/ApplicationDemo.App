using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDemo.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "EmailAddress", "Name" },
                values: new object[] { new Guid("da77f1c5-085a-4c12-a468-521e14665e15"), "BrentonBates@gmail.com", "Brenton Bates" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "EmailAddress", "Name" },
                values: new object[] { new Guid("6ee3c349-57e0-4894-aadc-898f39607097"), "SeanLivingston@gmail.com", "Sean Livingston" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "EmailAddress", "Name" },
                values: new object[] { new Guid("5da56949-03ae-4f9a-9632-204c6db5638f"), "StephonJohnson@gmail.com", "Stephon Johnson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
