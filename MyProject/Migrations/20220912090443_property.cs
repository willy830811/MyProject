using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingPrice = table.Column<float>(type: "real", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    OtherType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Use = table.Column<int>(type: "int", nullable: true),
                    OtherUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalArea = table.Column<float>(type: "real", nullable: true),
                    MainArea = table.Column<float>(type: "real", nullable: true),
                    AttachedArea = table.Column<float>(type: "real", nullable: true),
                    SharedArea = table.Column<float>(type: "real", nullable: true),
                    OtherArea = table.Column<float>(type: "real", nullable: true),
                    OtherAreaDefine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingPrice = table.Column<float>(type: "real", nullable: true),
                    HoldArea = table.Column<float>(type: "real", nullable: true),
                    LandSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingFinishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitPrice = table.Column<float>(type: "real", nullable: true),
                    Decorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GasFacility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balcony = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpperGroundFloors = table.Column<int>(type: "int", nullable: true),
                    UnderGroundFloors = table.Column<int>(type: "int", nullable: true),
                    SitDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoadWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LightingFace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCounts = table.Column<int>(type: "int", nullable: true),
                    HallCounts = table.Column<int>(type: "int", nullable: true),
                    ToliteCounts = table.Column<int>(type: "int", nullable: true),
                    NeiborCounts = table.Column<int>(type: "int", nullable: true),
                    ElevatorCounts = table.Column<int>(type: "int", nullable: true),
                    ElementarySchool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuniorHighSchool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Park = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MRTStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Rent = table.Column<float>(type: "real", nullable: true),
                    RentPeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentPeriodTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MainMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutsideMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courtyard = table.Column<bool>(type: "bit", nullable: true),
                    Guard = table.Column<bool>(type: "bit", nullable: true),
                    ManagementFee = table.Column<float>(type: "real", nullable: true),
                    Parking = table.Column<bool>(type: "bit", nullable: true),
                    ParkingArea = table.Column<float>(type: "real", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingFee = table.Column<float>(type: "real", nullable: true),
                    ParkingPrice = table.Column<float>(type: "real", nullable: true),
                    ParkingEntrance = table.Column<int>(type: "int", nullable: true),
                    ParkingType = table.Column<int>(type: "int", nullable: true),
                    BringingType = table.Column<int>(type: "int", nullable: true),
                    GiftPillar = table.Column<bool>(type: "bit", nullable: true),
                    GiftWallCabinet = table.Column<bool>(type: "bit", nullable: true),
                    GiftLiquorCabinet = table.Column<bool>(type: "bit", nullable: true),
                    GiftPhone = table.Column<bool>(type: "bit", nullable: true),
                    GiftSofa = table.Column<bool>(type: "bit", nullable: true),
                    GiftHeater = table.Column<bool>(type: "bit", nullable: true),
                    GiftBedding = table.Column<bool>(type: "bit", nullable: true),
                    GiftCooker = table.Column<bool>(type: "bit", nullable: true),
                    GiftGas = table.Column<bool>(type: "bit", nullable: true),
                    GiftTV = table.Column<int>(type: "int", nullable: true),
                    GiftFridge = table.Column<int>(type: "int", nullable: true),
                    GiftAirCon = table.Column<int>(type: "int", nullable: true),
                    GiftOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
