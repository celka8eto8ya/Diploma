using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedPersonalFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsDone = table.Column<int>(type: "int", nullable: false),
                    TotalTimeInProjects = table.Column<double>(type: "float", nullable: false),
                    AVGProjectTime = table.Column<double>(type: "float", nullable: false),
                    SetProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuccessTaskCompletion = table.Column<double>(type: "float", nullable: false),
                    AVGTaskCompletionPerMonth = table.Column<double>(type: "float", nullable: false),
                    AVGSalary = table.Column<double>(type: "float", nullable: false),
                    AVGTaskCost = table.Column<double>(type: "float", nullable: false),
                    AVGTaskOverdueTime = table.Column<double>(type: "float", nullable: false),
                    AVGTaskComplexity = table.Column<double>(type: "float", nullable: false),
                    AVGTaskCompletionTime = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalFiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalFiles_EmployeeId",
                table: "PersonalFiles",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalFiles");
        }
    }
}
