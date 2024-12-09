using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3___Data.Migrations
{
    /// <inheritdoc />
    public partial class TablaProduct3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Resources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resources",
                table: "Products",
                newName: "Price");
        }
    }
}
