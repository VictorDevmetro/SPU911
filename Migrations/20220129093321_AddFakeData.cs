using Microsoft.EntityFrameworkCore.Migrations;

namespace SPU911.Migrations
{
    public partial class AddFakeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "img/product01.png" },
                    { 2, "img/product02.png" },
                    { 3, "img/product03.png" },
                    { 4, "img/product04.png" },
                    { 5, "img/product05.png" },
                    { 6, "img/product06.png" },
                    { 7, "img/product07.png" },
                    { 8, "img/product08.png" },
                    { 9, "img/product09.png" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "CreateDate", "ImageId", "InWishList", "IsNew", "Price", "PriceOld", "ProductName", "ProductType", "Rate", "SalePercent" },
                values: new object[,]
                {
                    { 1, "Headphones", null, 1, false, false, 500m, 625m, "IPods", 3, 4, 15 },
                    { 2, "Laptops", null, 2, false, true, 2000m, 2599m, "MacBook Air", 0, 5, 0 },
                    { 3, "Desktop", null, 3, false, true, 5000m, 6599m, "ProBook", 0, 5, 5 },
                    { 4, "Cameras", null, 4, false, true, 5000m, 6599m, "Sony", 2, 3, 0 },
                    { 5, "Calls", null, 5, false, true, 2300m, 2599m, "MI Pro 10", 1, 2, 25 },
                    { 6, "Printer", null, 6, false, true, 350m, 599m, "Epson L5136", 3, 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
