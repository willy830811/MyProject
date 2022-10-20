using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class house_fix_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "House",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Owner_OwnerId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_OwnerId",
                table: "House");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "House",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
