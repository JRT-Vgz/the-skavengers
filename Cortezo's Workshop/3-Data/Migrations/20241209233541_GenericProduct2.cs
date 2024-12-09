using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3___Data.Migrations
{
    /// <inheritdoc />
    public partial class GenericProduct2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Materials_IdMaterial",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "GenericProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IdMaterial",
                table: "GenericProducts",
                newName: "IX_GenericProducts_IdMaterial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenericProducts",
                table: "GenericProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenericProducts_Materials_IdMaterial",
                table: "GenericProducts",
                column: "IdMaterial",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenericProducts_Materials_IdMaterial",
                table: "GenericProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenericProducts",
                table: "GenericProducts");

            migrationBuilder.RenameTable(
                name: "GenericProducts",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_GenericProducts_IdMaterial",
                table: "Products",
                newName: "IX_Products_IdMaterial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Materials_IdMaterial",
                table: "Products",
                column: "IdMaterial",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
