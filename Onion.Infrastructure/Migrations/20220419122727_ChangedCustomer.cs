using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class ChangedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Customers",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "CompanyName");
        }
    }
}
