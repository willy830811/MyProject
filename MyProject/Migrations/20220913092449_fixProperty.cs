using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class fixProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Property",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "OtherType",
                table: "Property",
                newName: "UpdateId");

            migrationBuilder.AlterColumn<int>(
                name: "OutsideMaterial",
                table: "Property",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainMaterial",
                table: "Property",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Property",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherMainMaterial",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherOutsideMaterial",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherPropertyType",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Property",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "OtherMainMaterial",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "OtherOutsideMaterial",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "OtherPropertyType",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "UpdateId",
                table: "Property",
                newName: "OtherType");

            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "Property",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "OutsideMaterial",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainMaterial",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
