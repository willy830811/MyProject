using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandInventoryItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandInventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseSourceId = table.Column<int>(type: "int", nullable: true),
                    AreaInPing = table.Column<float>(type: "real", nullable: true),
                    AreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    Hold = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoldAreaInPing = table.Column<float>(type: "real", nullable: true),
                    HoldAreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentValue = table.Column<float>(type: "real", nullable: true),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseSection = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandInventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                        column: x => x.CaseSourceId,
                        principalTable: "CaseSource",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LandInventoryItem_CaseSourceId",
                table: "LandInventoryItem",
                column: "CaseSourceId");
        }
    }
}
