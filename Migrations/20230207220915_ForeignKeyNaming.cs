using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelioGaming.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Person",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Person",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Company",
                newName: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Person",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Person",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Company",
                newName: "Address");
        }
    }
}
