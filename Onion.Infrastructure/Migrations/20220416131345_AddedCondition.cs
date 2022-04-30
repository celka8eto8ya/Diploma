using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_Projects_ProjectId",
                table: "Conditions");

            migrationBuilder.DropIndex(
                name: "IX_Conditions_ProjectId",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "SetDate",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "SubTaskId",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Conditions");

            migrationBuilder.RenameColumn(
                name: "Instruction",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "EmployeeAmount",
                table: "Projects",
                newName: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ConditionId",
                table: "Projects",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Conditions_ConditionId",
                table: "Projects",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Conditions_ConditionId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ConditionId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "Instruction");

            migrationBuilder.RenameColumn(
                name: "ConditionId",
                table: "Projects",
                newName: "EmployeeAmount");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SetDate",
                table: "Conditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubTaskId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ProjectId",
                table: "Conditions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_Projects_ProjectId",
                table: "Conditions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
