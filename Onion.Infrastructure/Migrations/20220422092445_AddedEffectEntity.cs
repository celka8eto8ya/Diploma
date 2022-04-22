using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedEffectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IRR = table.Column<double>(type: "float", nullable: false),
                    ROI = table.Column<double>(type: "float", nullable: false),
                    NPV = table.Column<double>(type: "float", nullable: false),
                    ETC = table.Column<double>(type: "float", nullable: false),
                    PCT_A = table.Column<double>(type: "float", nullable: false),
                    PCT_T = table.Column<double>(type: "float", nullable: false),
                    POT = table.Column<double>(type: "float", nullable: false),
                    POA = table.Column<double>(type: "float", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Effects_ProjectId",
                table: "Effects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effects");
        }
    }
}
