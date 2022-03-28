using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedConditionDepartTypeTeamAndChangeSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EmployeeEmount",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "TechStack",
                table: "Employees",
                newName: "TechStackName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Expirence",
                table: "Employees",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Departments",
                newName: "EmployeeAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "SetDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeAmount",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TechStack",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UseArea",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    SubTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Functions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentTypes_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeAmount = table.Column<int>(type: "int", nullable: false),
                    Technologies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ProjectId",
                table: "Conditions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentTypes_DepartmentId",
                table: "DepartmentTypes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProjectId",
                table: "Teams",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "DepartmentTypes");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SetDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmployeeAmount",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TechStack",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UseArea",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TechStackName",
                table: "Employees",
                newName: "TechStack");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Employees",
                newName: "Expirence");

            migrationBuilder.RenameColumn(
                name: "EmployeeAmount",
                table: "Departments",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmount",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
