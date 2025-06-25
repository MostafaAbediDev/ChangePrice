using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CountRenamedToDefaultCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPriceRial",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Products",
                newName: "DefaultCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultCount",
                table: "Products",
                newName: "Count");

            migrationBuilder.AddColumn<long>(
                name: "TotalPriceRial",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
