using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelioGaming.Migrations
{
    /// <inheritdoc />
    public partial class PersonForeignKeyRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Company_CompanyId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CompanyId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Person",
                newName: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Person",
                newName: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CompanyId",
                table: "Person",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Company_CompanyId",
                table: "Person",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
