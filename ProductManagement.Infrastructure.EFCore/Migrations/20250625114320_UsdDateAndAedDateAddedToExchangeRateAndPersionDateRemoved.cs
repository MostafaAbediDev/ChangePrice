using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UsdDateAndAedDateAddedToExchangeRateAndPersionDateRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "PersianDate",
                table: "ExchangeRates",
                newName: "UsdDate");

            migrationBuilder.AddColumn<string>(
                name: "AedDate",
                table: "ExchangeRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AedDate",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "UsdDate",
                table: "ExchangeRates",
                newName: "PersianDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ExchangeRates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
