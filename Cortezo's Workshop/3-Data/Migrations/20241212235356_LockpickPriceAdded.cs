using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3___Data.Migrations
{
    /// <inheritdoc />
    public partial class LockpickPriceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LockpickPrice",
                table: "IngotResources",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockpickPrice",
                table: "IngotResources");
        }
    }
}
