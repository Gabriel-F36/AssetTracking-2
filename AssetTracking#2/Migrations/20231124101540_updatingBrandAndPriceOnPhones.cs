using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class updatingBrandAndPriceOnPhones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "brand", "price" },
                values: new object[] { "Nokia (SEK)", 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "brand", "price" },
                values: new object[] { "Nokia (USD)", 100 });
        }
    }
}
