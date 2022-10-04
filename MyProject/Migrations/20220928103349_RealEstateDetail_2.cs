using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class RealEstateDetail_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurroundingsAppendiceTypes",
                table: "RealEstateDetail",
                newName: "UpdateId");

            migrationBuilder.RenameColumn(
                name: "SettingOtherRightsTypes",
                table: "RealEstateDetail",
                newName: "SurroundingsAppendiceType");

            migrationBuilder.RenameColumn(
                name: "RestrictingRegistrationTypes",
                table: "RealEstateDetail",
                newName: "SettingOtherRightsType");

            migrationBuilder.RenameColumn(
                name: "RespectivelyManageBy826Types",
                table: "RealEstateDetail",
                newName: "RestrictingRegistrationType");

            migrationBuilder.RenameColumn(
                name: "PolutedAreaTypes",
                table: "RealEstateDetail",
                newName: "RespectivelyManageBy826Type");

            migrationBuilder.RenameColumn(
                name: "OtherRightsTypes",
                table: "RealEstateDetail",
                newName: "PolutedAreaType");

            migrationBuilder.RenameColumn(
                name: "NationalParkTypes",
                table: "RealEstateDetail",
                newName: "OtherRightsType");

            migrationBuilder.RenameColumn(
                name: "DrinkingWaterSourceTypes",
                table: "RealEstateDetail",
                newName: "NationalParkType");

            migrationBuilder.RenameColumn(
                name: "DevelopMethodRestrictionsTypes",
                table: "RealEstateDetail",
                newName: "DrinkingWaterSourceType");

            migrationBuilder.RenameColumn(
                name: "ChooseManageTypes",
                table: "RealEstateDetail",
                newName: "DevelopMethodRestrictionsType");

            migrationBuilder.RenameColumn(
                name: "BuildFarmhouseTypes",
                table: "RealEstateDetail",
                newName: "CreateId");

            migrationBuilder.AddColumn<string>(
                name: "BuildFarmhouseType",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChooseManageType",
                table: "RealEstateDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "RealEstateDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "RealEstateDetail",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildFarmhouseType",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "ChooseManageType",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "RealEstateDetail");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "RealEstateDetail");

            migrationBuilder.RenameColumn(
                name: "UpdateId",
                table: "RealEstateDetail",
                newName: "SurroundingsAppendiceTypes");

            migrationBuilder.RenameColumn(
                name: "SurroundingsAppendiceType",
                table: "RealEstateDetail",
                newName: "SettingOtherRightsTypes");

            migrationBuilder.RenameColumn(
                name: "SettingOtherRightsType",
                table: "RealEstateDetail",
                newName: "RestrictingRegistrationTypes");

            migrationBuilder.RenameColumn(
                name: "RestrictingRegistrationType",
                table: "RealEstateDetail",
                newName: "RespectivelyManageBy826Types");

            migrationBuilder.RenameColumn(
                name: "RespectivelyManageBy826Type",
                table: "RealEstateDetail",
                newName: "PolutedAreaTypes");

            migrationBuilder.RenameColumn(
                name: "PolutedAreaType",
                table: "RealEstateDetail",
                newName: "OtherRightsTypes");

            migrationBuilder.RenameColumn(
                name: "OtherRightsType",
                table: "RealEstateDetail",
                newName: "NationalParkTypes");

            migrationBuilder.RenameColumn(
                name: "NationalParkType",
                table: "RealEstateDetail",
                newName: "DrinkingWaterSourceTypes");

            migrationBuilder.RenameColumn(
                name: "DrinkingWaterSourceType",
                table: "RealEstateDetail",
                newName: "DevelopMethodRestrictionsTypes");

            migrationBuilder.RenameColumn(
                name: "DevelopMethodRestrictionsType",
                table: "RealEstateDetail",
                newName: "ChooseManageTypes");

            migrationBuilder.RenameColumn(
                name: "CreateId",
                table: "RealEstateDetail",
                newName: "BuildFarmhouseTypes");
        }
    }
}
