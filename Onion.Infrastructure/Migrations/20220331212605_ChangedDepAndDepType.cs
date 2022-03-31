using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onion.Infrastructure.Migrations
{
    public partial class ChangedDepAndDepType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTypes_Departments_DepartmentId",
                table: "DepartmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentTypes_DepartmentId",
                table: "DepartmentTypes");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "DepartmentTypes");

            migrationBuilder.DropColumn(
                name: "SetDate",
                table: "DepartmentTypes");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTypeId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentTypeId",
                table: "Departments",
                column: "DepartmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepartmentTypes_DepartmentTypeId",
                table: "Departments",
                column: "DepartmentTypeId",
                principalTable: "DepartmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepartmentTypes_DepartmentTypeId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentTypeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentTypeId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "DepartmentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SetDate",
                table: "DepartmentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentTypes_DepartmentId",
                table: "DepartmentTypes",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTypes_Departments_DepartmentId",
                table: "DepartmentTypes",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
