using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "LandInventories",
                table: "CaseSource",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem",
                column: "CaseSourceId",
                principalTable: "CaseSource",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem");

            migrationBuilder.DropColumn(
                name: "LandInventories",
                table: "CaseSource");

            migrationBuilder.AlterColumn<int>(
                name: "CaseSourceId",
                table: "LandInventoryItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem",
                column: "CaseSourceId",
                principalTable: "CaseSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
