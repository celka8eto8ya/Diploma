using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "ST",
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
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    ReviewStageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ST", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ST_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ST_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ST_ReviewStages_ReviewStageId",
                        column: x => x.ReviewStageId,
                        principalTable: "ReviewStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ST");

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountCompletionTasks = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentCompletionTasks = table.Column<double>(type: "float", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ReviewStageId = table.Column<int>(type: "int", nullable: false),
                    TaskAmount = table.Column<int>(type: "int", nullable: false),
                    TechStack = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_ReviewStages_ReviewStageId",
                        column: x => x.ReviewStageId,
                        principalTable: "ReviewStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ConditionId",
                table: "Steps",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ProjectId",
                table: "Steps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ReviewStageId",
                table: "Steps",
                column: "ReviewStageId");
        }
    }
}
