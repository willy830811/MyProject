using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class add_realestate_detail_landInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Owner_OwnerId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_OwnerId",
                table: "House");

            migrationBuilder.AddColumn<string>(
                name: "LandInventories",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandInventories",
                table: "RealEstateDetail");

            migrationBuilder.CreateIndex(
                name: "IX_House_OwnerId",
                table: "House",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Owner_OwnerId",
                table: "House",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id");
        }
    }
}
