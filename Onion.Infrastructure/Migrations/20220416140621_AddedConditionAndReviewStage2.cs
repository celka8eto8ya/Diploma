using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class AddedConditionAndReviewStage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewStage",
                table: "Conditions");

            migrationBuilder.AddColumn<int>(
                name: "ReviewStageId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReviewStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewStages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ReviewStageId",
                table: "Projects",
                column: "ReviewStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ReviewStages_ReviewStageId",
                table: "Projects",
                column: "ReviewStageId",
                principalTable: "ReviewStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ReviewStages_ReviewStageId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ReviewStages");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ReviewStageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ReviewStageId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "ReviewStage",
                table: "Conditions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
