using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class EditedOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Operations",
                newName: "Object");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Object",
                table: "Operations",
                newName: "Name");

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Operations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
