using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class ChangedNamesFieldEffect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POA",
                table: "Effects",
                newName: "OT");

            migrationBuilder.RenameColumn(
                name: "PCT_A",
                table: "Effects",
                newName: "CT_T");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OT",
                table: "Effects",
                newName: "POA");

            migrationBuilder.RenameColumn(
                name: "CT_T",
                table: "Effects",
                newName: "PCT_A");
        }
    }
}
