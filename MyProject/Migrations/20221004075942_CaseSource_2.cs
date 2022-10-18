using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppendixItem_CaseCourse_CaseSourseId",
                table: "AppendixItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseCourse_CaseSourseId",
                table: "LandInventoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseCourse",
                table: "CaseCourse");

            migrationBuilder.RenameTable(
                name: "CaseCourse",
                newName: "CaseSourse");

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "CaseSourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "CaseSourse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateId",
                table: "CaseSourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CaseSourse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseSourse",
                table: "CaseSourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppendixItem_CaseSourse_CaseSourseId",
                table: "AppendixItem",
                column: "CaseSourseId",
                principalTable: "CaseSourse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandInventoryItem_CaseSourse_CaseSourseId",
                table: "LandInventoryItem",
                column: "CaseSourseId",
                principalTable: "CaseSourse",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppendixItem_CaseSourse_CaseSourseId",
                table: "AppendixItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseSourse_CaseSourseId",
                table: "LandInventoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseSourse",
                table: "CaseSourse");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "CaseSourse");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "CaseSourse");

            migrationBuilder.DropColumn(
                name: "UpdateId",
                table: "CaseSourse");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CaseSourse");

            migrationBuilder.RenameTable(
                name: "CaseSourse",
                newName: "CaseCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseCourse",
                table: "CaseCourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppendixItem_CaseCourse_CaseSourseId",
                table: "AppendixItem",
                column: "CaseSourseId",
                principalTable: "CaseCourse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandInventoryItem_CaseCourse_CaseSourseId",
                table: "LandInventoryItem",
                column: "CaseSourseId",
                principalTable: "CaseCourse",
                principalColumn: "Id");
        }
    }
}
