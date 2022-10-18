using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppendixItem_CaseSource_CaseSourceId",
                table: "AppendixItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem");

            migrationBuilder.AlterColumn<int>(
                name: "CaseSourceId",
                table: "LandInventoryItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaseSourceId",
                table: "AppendixItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppendixItem_CaseSource_CaseSourceId",
                table: "AppendixItem",
                column: "CaseSourceId",
                principalTable: "CaseSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem",
                column: "CaseSourceId",
                principalTable: "CaseSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppendixItem_CaseSource_CaseSourceId",
                table: "AppendixItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem");

            migrationBuilder.AlterColumn<int>(
                name: "CaseSourceId",
                table: "LandInventoryItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaseSourceId",
                table: "AppendixItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AppendixItem_CaseSource_CaseSourceId",
                table: "AppendixItem",
                column: "CaseSourceId",
                principalTable: "CaseSource",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem",
                column: "CaseSourceId",
                principalTable: "CaseSource",
                principalColumn: "Id");
        }
    }
}
