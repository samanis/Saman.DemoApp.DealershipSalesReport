using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Saman.DemoApp.DealershipSalesReport.Migrations
{
    public partial class dealershipnameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DelaerShips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelaerShips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealNumber = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    DealershipName = table.Column<string>(nullable: true),
                    Vehicle = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealNumber = table.Column<int>(nullable: false),
                    ReportFileId = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    DealershipId = table.Column<int>(nullable: true),
                    Vehicle = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_DelaerShips_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "DelaerShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_ReportFiles_ReportFileId",
                        column: x => x.ReportFileId,
                        principalTable: "ReportFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DealershipId",
                table: "Sales",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ReportFileId",
                table: "Sales",
                column: "ReportFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReports");

            migrationBuilder.DropTable(
                name: "DelaerShips");

            migrationBuilder.DropTable(
                name: "ReportFiles");
        }
    }
}
