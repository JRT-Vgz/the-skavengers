using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3___Data.Migrations
{
    /// <inheritdoc />
    public partial class GenProdActualizado2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resources",
                table: "GenericProducts",
                newName: "MaterialUsed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialUsed",
                table: "GenericProducts",
                newName: "Resources");
        }
    }
}
