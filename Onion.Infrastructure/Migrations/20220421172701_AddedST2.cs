using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedST2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ST_Conditions_ConditionId",
                table: "ST");

            migrationBuilder.DropForeignKey(
                name: "FK_ST_Projects_ProjectId",
                table: "ST");

            migrationBuilder.DropForeignKey(
                name: "FK_ST_ReviewStages_ReviewStageId",
                table: "ST");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewStageId",
                table: "ST",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ST",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionId",
                table: "ST",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ST_Conditions_ConditionId",
                table: "ST",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ST_Projects_ProjectId",
                table: "ST",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ST_ReviewStages_ReviewStageId",
                table: "ST",
                column: "ReviewStageId",
                principalTable: "ReviewStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ST_Conditions_ConditionId",
                table: "ST");

            migrationBuilder.DropForeignKey(
                name: "FK_ST_Projects_ProjectId",
                table: "ST");

            migrationBuilder.DropForeignKey(
                name: "FK_ST_ReviewStages_ReviewStageId",
                table: "ST");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewStageId",
                table: "ST",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ST",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConditionId",
                table: "ST",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ST_Conditions_ConditionId",
                table: "ST",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ST_Projects_ProjectId",
                table: "ST",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ST_ReviewStages_ReviewStageId",
                table: "ST",
                column: "ReviewStageId",
                principalTable: "ReviewStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
