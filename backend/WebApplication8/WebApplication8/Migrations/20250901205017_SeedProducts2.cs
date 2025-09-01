using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication8.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    oldPrice = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Image", "Name", "Price", "Qty", "discount", "oldPrice" },
                values: new object[,]
                {
                    { 1, "images/product/large-size/1.jpg", "Accusantium Dolorem1", 46.80m, 1, 7, 50 },
                    { 2, "images/product/large-size/2.jpg", "Mug Today Is A Good Day", 71.80m, 2, 5, 77 },
                    { 3, "images/product/large-size/3.jpg", "Accusantium Dolorem1", 46.80m, 3, 0, 0 },
                    { 4, "images/product/large-size/4.jpg", "Mug Today Is A Good Day", 71.80m, 4, 0, 0 },
                    { 5, "images/product/large-size/5.jpg", "Accusantium Dolorem1", 46.80m, 5, 4, 50 },
                    { 6, "images/product/large-size/6.jpg", "Mug Today Is A Good Day", 71.80m, 6, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
