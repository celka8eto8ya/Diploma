using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Conditions_ConditionId",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Projects_ProjectId",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_ReviewStages_ReviewStageId",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.RenameTable(
                name: "Step",
                newName: "Steps");

            migrationBuilder.RenameIndex(
                name: "IX_Step_ReviewStageId",
                table: "Steps",
                newName: "IX_Steps_ReviewStageId");

            migrationBuilder.RenameIndex(
                name: "IX_Step_ProjectId",
                table: "Steps",
                newName: "IX_Steps_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Step_ConditionId",
                table: "Steps",
                newName: "IX_Steps_ConditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steps",
                table: "Steps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complexity = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    ReviewStageId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    StepId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_ReviewStages_ReviewStageId",
                        column: x => x.ReviewStageId,
                        principalTable: "ReviewStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ConditionId",
                table: "Tasks",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ReviewStageId",
                table: "Tasks",
                column: "ReviewStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StepId",
                table: "Tasks",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Conditions_ConditionId",
                table: "Steps",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Projects_ProjectId",
                table: "Steps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_ReviewStages_ReviewStageId",
                table: "Steps",
                column: "ReviewStageId",
                principalTable: "ReviewStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Conditions_ConditionId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Projects_ProjectId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_ReviewStages_ReviewStageId",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steps",
                table: "Steps");

            migrationBuilder.RenameTable(
                name: "Steps",
                newName: "Step");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_ReviewStageId",
                table: "Step",
                newName: "IX_Step_ReviewStageId");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_ProjectId",
                table: "Step",
                newName: "IX_Step_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_ConditionId",
                table: "Step",
                newName: "IX_Step_ConditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Conditions_ConditionId",
                table: "Step",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Projects_ProjectId",
                table: "Step",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_ReviewStages_ReviewStageId",
                table: "Step",
                column: "ReviewStageId",
                principalTable: "ReviewStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
