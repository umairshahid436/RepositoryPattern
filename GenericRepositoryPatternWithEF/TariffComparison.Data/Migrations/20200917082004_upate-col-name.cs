using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffComparison.Data.Migrations
{
    public partial class upatecolname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tariff",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "TariffName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TariffName",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Tariff",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
