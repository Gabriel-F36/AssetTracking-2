using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class updatingPurchaseDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 1,
                column: "purchaseDate",
                value: "2021-01-24");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 2,
                column: "purchaseDate",
                value: "2021-04-24");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 3,
                column: "purchaseDate",
                value: "2022-04-24");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 1,
                column: "purchaseDate",
                value: "2021-01-12");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 2,
                column: "purchaseDate",
                value: "2021-04-12");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 3,
                column: "purchaseDate",
                value: "2022-04-12");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 1,
                column: "purchaseDate",
                value: "2023-09-24");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 2,
                column: "purchaseDate",
                value: "2023-07-24");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 3,
                column: "purchaseDate",
                value: "2023-04-24");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 1,
                column: "purchaseDate",
                value: "2023-09-12");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 2,
                column: "purchaseDate",
                value: "2023-07-12");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 3,
                column: "purchaseDate",
                value: "2023-04-12");
        }
    }
}
