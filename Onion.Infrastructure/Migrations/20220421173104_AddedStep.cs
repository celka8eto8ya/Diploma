using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ST");

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechStack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskAmount = table.Column<int>(type: "int", nullable: false),
                    PercentCompletionTasks = table.Column<double>(type: "float", nullable: false),
                    AmountCompletionTasks = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    ReviewStageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Step_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Step_ReviewStages_ReviewStageId",
                        column: x => x.ReviewStageId,
                        principalTable: "ReviewStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_ConditionId",
                table: "Step",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_ProjectId",
                table: "Step",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_ReviewStageId",
                table: "Step",
                column: "ReviewStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.CreateTable(
                name: "ST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountCompletionTasks = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentCompletionTasks = table.Column<double>(type: "float", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ReviewStageId = table.Column<int>(type: "int", nullable: true),
                    TaskAmount = table.Column<int>(type: "int", nullable: false),
                    TechStack = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ST_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ST_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ST_ReviewStages_ReviewStageId",
                        column: x => x.ReviewStageId,
                        principalTable: "ReviewStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ST_ConditionId",
                table: "ST",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ST_ProjectId",
                table: "ST",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ST_ReviewStageId",
                table: "ST",
                column: "ReviewStageId");
        }
    }
}
