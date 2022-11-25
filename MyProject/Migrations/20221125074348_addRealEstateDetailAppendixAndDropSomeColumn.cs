using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class addRealEstateDetailAppendixAndDropSomeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppendicesNames",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "ObjectName",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "PlaceNumber",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "RightsScope",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "Subsection",
                table: "RealEstateDetail");

            migrationBuilder.CreateTable(
                name: "RealEstateDetailAppendixItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealEstateDetailId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppendixType = table.Column<int>(type: "int", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateDetailAppendixItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateDetailAppendixItem_RealEstateDetail_RealEstateDetailId",
                        column: x => x.RealEstateDetailId,
                        principalTable: "RealEstateDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateDetailAppendixItem_RealEstateDetailId",
                table: "RealEstateDetailAppendixItem",
                column: "RealEstateDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateDetailAppendixItem");

            migrationBuilder.AddColumn<string>(
                name: "AppendicesNames",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Area",
                table: "RealEstateDetail",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjectName",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceNumber",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RightsScope",
                table: "RealEstateDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subsection",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
