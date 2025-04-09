using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_Data.CortezosWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenericProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    QuantityCrafted = table.Column<int>(type: "int", nullable: false),
                    MaterialUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericProducts_Materials_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngotResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    MapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapQuantity = table.Column<int>(type: "int", nullable: false),
                    MapTotalOre = table.Column<int>(type: "int", nullable: false),
                    MapRecommendedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullPlatePrice = table.Column<int>(type: "int", nullable: false),
                    ToolPrice = table.Column<int>(type: "int", nullable: false),
                    LockpicksPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngotResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngotResources_Materials_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenericProducts_IdMaterial",
                table: "GenericProducts",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_IngotResources_IdMaterial",
                table: "IngotResources",
                column: "IdMaterial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericProducts");

            migrationBuilder.DropTable(
                name: "IngotResources");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ShopStats");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
