using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class CaseSource_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppendixItem_CaseSourse_CaseSourseId",
                table: "AppendixItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseSourse_CaseSourseId",
                table: "LandInventoryItem");

            migrationBuilder.DropTable(
                name: "CaseSourse");

            migrationBuilder.RenameColumn(
                name: "CaseSourseId",
                table: "LandInventoryItem",
                newName: "CaseSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_LandInventoryItem_CaseSourseId",
                table: "LandInventoryItem",
                newName: "IX_LandInventoryItem_CaseSourceId");

            migrationBuilder.RenameColumn(
                name: "CaseSourseId",
                table: "AppendixItem",
                newName: "CaseSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_AppendixItem_CaseSourseId",
                table: "AppendixItem",
                newName: "IX_AppendixItem_CaseSourceId");

            migrationBuilder.CreateTable(
                name: "CaseSource",
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
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSource", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppendixItem_CaseSource_CaseSourceId",
                table: "AppendixItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LandInventoryItem_CaseSource_CaseSourceId",
                table: "LandInventoryItem");

            migrationBuilder.DropTable(
                name: "CaseSource");

            migrationBuilder.RenameColumn(
                name: "CaseSourceId",
                table: "LandInventoryItem",
                newName: "CaseSourseId");

            migrationBuilder.RenameIndex(
                name: "IX_LandInventoryItem_CaseSourceId",
                table: "LandInventoryItem",
                newName: "IX_LandInventoryItem_CaseSourseId");

            migrationBuilder.RenameColumn(
                name: "CaseSourceId",
                table: "AppendixItem",
                newName: "CaseSourseId");

            migrationBuilder.RenameIndex(
                name: "IX_AppendixItem_CaseSourceId",
                table: "AppendixItem",
                newName: "IX_AppendixItem_CaseSourseId");

            migrationBuilder.CreateTable(
                name: "CaseSourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildRate = table.Column<float>(type: "real", nullable: true),
                    CaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hold = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAerialPhoto = table.Column<bool>(type: "bit", nullable: true),
                    IsCadastralMap = table.Column<bool>(type: "bit", nullable: true),
                    IsCurrentPhotos = table.Column<bool>(type: "bit", nullable: true),
                    IsTranscript = table.Column<bool>(type: "bit", nullable: true),
                    IsUrbanPlanningManual = table.Column<bool>(type: "bit", nullable: true),
                    IsUseSection = table.Column<bool>(type: "bit", nullable: true),
                    LandCount = table.Column<int>(type: "int", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingAreaInPing = table.Column<float>(type: "real", nullable: true),
                    SellingAreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    Subsection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAreaInPing = table.Column<float>(type: "real", nullable: true),
                    TotalAreaInSquareMeter = table.Column<float>(type: "real", nullable: true),
                    TotalPrice = table.Column<float>(type: "real", nullable: true),
                    UnitPrice = table.Column<float>(type: "real", nullable: true),
                    UpdateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UseSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueAddedTax = table.Column<float>(type: "real", nullable: true),
                    VolumeRate = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSourse", x => x.Id);
                });

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
    }
}
