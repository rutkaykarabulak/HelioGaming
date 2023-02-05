using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelioGaming.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeCount",
                table: "Company",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeCount",
                table: "Company");
        }
    }
}
