using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class ChangedEffect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IRR_CashFlows",
                table: "Effects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IRR_DiscountRate",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IRR_InitialInvestments",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "IRR_YearsAmount",
                table: "Effects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NPV_CashFlows",
                table: "Effects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NPV_DiscountRate",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NPV_InitialInvestments",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NPV_YearsAmount",
                table: "Effects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ROI_ExpensesAmount",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ROI_InvestmentsAmount",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ROI_InvestmentsIncome",
                table: "Effects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IRR_CashFlows",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "IRR_DiscountRate",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "IRR_InitialInvestments",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "IRR_YearsAmount",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "NPV_CashFlows",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "NPV_DiscountRate",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "NPV_InitialInvestments",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "NPV_YearsAmount",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "ROI_ExpensesAmount",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "ROI_InvestmentsAmount",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "ROI_InvestmentsIncome",
                table: "Effects");
        }
    }
}
