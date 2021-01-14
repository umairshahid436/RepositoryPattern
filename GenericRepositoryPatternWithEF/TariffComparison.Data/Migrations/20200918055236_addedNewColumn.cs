using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffComparison.Data.Migrations
{
    public partial class addedNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Consumption",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PackageType",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Products");
        }
    }
}
