using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedOperationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Operations");
        }
    }
}
