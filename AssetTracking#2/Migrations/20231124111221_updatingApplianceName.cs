using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class updatingApplianceName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applianceName",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "applianceName",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 1,
                column: "applianceName",
                value: "Laptop Computer");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 2,
                column: "applianceName",
                value: "Laptop Computer");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "id",
                keyValue: 3,
                column: "applianceName",
                value: "Laptop Computer");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 1,
                column: "applianceName",
                value: "Mobile Phone");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 2,
                column: "applianceName",
                value: "Mobile Phone");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "id",
                keyValue: 3,
                column: "applianceName",
                value: "Mobile Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "applianceName",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "applianceName",
                table: "Laptops");
        }
    }
}
