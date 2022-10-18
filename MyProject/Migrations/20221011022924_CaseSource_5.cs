using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LandInventoryItem",
                newName: "SectionName");

            migrationBuilder.AddColumn<float>(
                name: "HoldAreaInPing",
                table: "LandInventoryItem",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HoldAreaInSquareMeter",
                table: "LandInventoryItem",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoldAreaInPing",
                table: "LandInventoryItem");

            migrationBuilder.DropColumn(
                name: "HoldAreaInSquareMeter",
                table: "LandInventoryItem");

            migrationBuilder.RenameColumn(
                name: "SectionName",
                table: "LandInventoryItem",
                newName: "Name");
        }
    }
}
