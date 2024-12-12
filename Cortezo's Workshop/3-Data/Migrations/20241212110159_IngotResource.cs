using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3___Data.Migrations
{
    /// <inheritdoc />
    public partial class IngotResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngotResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    MapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapQuantity = table.Column<int>(type: "int", nullable: false),
                    MapTotalOre = table.Column<int>(type: "int", nullable: false),
                    MapRecommendedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullPlatePrice = table.Column<int>(type: "int", nullable: false),
                    ToolPrice = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_IngotResources_IdMaterial",
                table: "IngotResources",
                column: "IdMaterial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngotResources");
        }
    }
}
