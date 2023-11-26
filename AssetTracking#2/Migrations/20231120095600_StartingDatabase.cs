using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTracking_2.Migrations
{
    public partial class StartingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //hello this is a atest
            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    screenSizeInches = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    screenSizeInches = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
