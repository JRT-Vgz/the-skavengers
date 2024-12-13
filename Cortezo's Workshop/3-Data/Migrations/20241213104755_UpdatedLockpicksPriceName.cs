using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3___Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedLockpicksPriceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LockpickPrice",
                table: "IngotResources",
                newName: "LockpicksPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LockpicksPrice",
                table: "IngotResources",
                newName: "LockpickPrice");
        }
    }
}
