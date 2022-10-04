using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<float>(type: "real", nullable: true),
                    UnitPrice = table.Column<float>(type: "real", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subsection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandCount = table.Column<int>(type: "int", nullable: true),
                    TotalAreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    TotalAreaInPing = table.Column<float>(type: "real", nullable: true),
                    BuildRate = table.Column<float>(type: "real", nullable: true),
                    VolumeRate = table.Column<float>(type: "real", nullable: true),
                    Hold = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingAreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    SellingAreaInPing = table.Column<float>(type: "real", nullable: true),
                    UseSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCadastralMap = table.Column<bool>(type: "bit", nullable: true),
                    IsAerialPhoto = table.Column<bool>(type: "bit", nullable: true),
                    IsTranscript = table.Column<bool>(type: "bit", nullable: true),
                    IsUseSection = table.Column<bool>(type: "bit", nullable: true),
                    IsUrbanPlanningManual = table.Column<bool>(type: "bit", nullable: true),
                    IsCurrentPhotos = table.Column<bool>(type: "bit", nullable: true),
                    ValueAddedTax = table.Column<float>(type: "real", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppendixItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseSourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppendixItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppendixItem_CaseCourse_CaseSourseId",
                        column: x => x.CaseSourseId,
                        principalTable: "CaseCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LandInventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    AreaInPing = table.Column<float>(type: "real", nullable: true),
                    Hold = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentValue = table.Column<float>(type: "real", nullable: true),
                    UseSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseSourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandInventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandInventoryItem_CaseCourse_CaseSourseId",
                        column: x => x.CaseSourseId,
                        principalTable: "CaseCourse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppendixItem_CaseSourseId",
                table: "AppendixItem",
                column: "CaseSourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LandInventoryItem_CaseSourseId",
                table: "LandInventoryItem",
                column: "CaseSourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppendixItem");

            migrationBuilder.DropTable(
                name: "LandInventoryItem");

            migrationBuilder.DropTable(
                name: "CaseCourse");
        }
    }
}
