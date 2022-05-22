using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEProjectApp.DataAccess.Migrations
{
    public partial class assMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Furnisor",
                columns: table => new
                {
                    FurnisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnisor", x => x.FurnisorId);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNo = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartment_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentNo = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: true),
                    FurnisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_Invoice_Furnisor_FurnisorId",
                        column: x => x.FurnisorId,
                        principalTable: "Furnisor",
                        principalColumn: "FurnisorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingId",
                table: "Apartment",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ApartmentId",
                table: "Invoice",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_FurnisorId",
                table: "Invoice",
                column: "FurnisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Furnisor");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
