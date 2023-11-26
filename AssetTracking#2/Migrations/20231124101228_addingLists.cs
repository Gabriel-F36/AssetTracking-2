using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class addingLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "id", "brand", "modelName", "price", "purchaseDate", "screenSizeInches" },
                values: new object[,]
                {
                    { 1, "MacBook (USD)", "Air", 1300, "2023-09-24", 15 },
                    { 2, "Asus (SEK)", "Zenbook S 13", 15000, "2023-07-24", 13 },
                    { 3, "Lenovo (SEK)", "ThinkPad T14s Gen 3", 18000, "2023-04-24", 14 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "id", "brand", "modelName", "price", "purchaseDate", "screenSizeInches" },
                values: new object[,]
                {
                    { 1, "iPhone (USD)", "14", 700, "2023-09-12", 6 },
                    { 2, "Samsung (USD)", "Galaxy S23", 860, "2023-07-12", 7 },
                    { 3, "Nokia (USD)", "G100", 100, "2023-04-12", 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
