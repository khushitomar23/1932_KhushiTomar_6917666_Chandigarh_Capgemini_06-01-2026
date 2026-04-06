using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-performance laptop", "Laptop Pro", 1299.99m, null },
                    { 2, "Electronics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic wireless mouse", "Wireless Mouse", 49.99m, null },
                    { 3, "Furniture", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic office chair", "Desk Chair", 399.00m, null },
                    { 4, "Appliances", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12-cup programmable", "Coffee Maker", 89.95m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category",
                table: "Products",
                column: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
