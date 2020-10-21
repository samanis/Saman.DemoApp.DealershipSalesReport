using Microsoft.EntityFrameworkCore.Migrations;

namespace Saman.DemoApp.DealershipSalesReport.Migrations
{
    public partial class FileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "SalesReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "SalesReports");
        }
    }
}
