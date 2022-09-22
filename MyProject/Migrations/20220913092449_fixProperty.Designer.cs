﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.Data;

#nullable disable

namespace MyProject.Migrations
{
    [DbContext(typeof(MyProjectContext))]
    [Migration("20220913092449_fixProperty")]
    partial class fixProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyProject.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("MyProject.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float?>("Area")
                        .HasColumnType("real");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegisterReason")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShareDenominator")
                        .HasColumnType("int");

                    b.Property<int?>("ShareNumerator")
                        .HasColumnType("int");

                    b.Property<string>("Subsection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("MyProject.Models.HouseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HouseUser");
                });

            modelBuilder.Entity("MyProject.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Residence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("MyProject.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("AttachedArea")
                        .HasColumnType("real");

                    b.Property<string>("Balcony")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BringingType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BuildingFinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CaseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Courtyard")
                        .HasColumnType("bit");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Decorate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementarySchool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ElevatorCounts")
                        .HasColumnType("int");

                    b.Property<string>("FaceDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Feature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GasFacility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GiftAirCon")
                        .HasColumnType("int");

                    b.Property<bool?>("GiftBedding")
                        .HasColumnType("bit");

                    b.Property<bool?>("GiftCooker")
                        .HasColumnType("bit");

                    b.Property<int?>("GiftFridge")
                        .HasColumnType("int");

                    b.Property<bool?>("GiftGas")
                        .HasColumnType("bit");

                    b.Property<bool?>("GiftHeater")
                        .HasColumnType("bit");

                    b.Property<bool?>("GiftLiquorCabinet")
                        .HasColumnType("bit");

                    b.Property<string>("GiftOther")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("GiftPhone")
                        .HasColumnType("bit");

                    b.Property<bool?>("GiftPillar")
                        .HasColumnType("bit");

                    b.Property<bool?>("GiftSofa")
                        .HasColumnType("bit");

                    b.Property<int?>("GiftTV")
                        .HasColumnType("int");

                    b.Property<bool?>("GiftWallCabinet")
                        .HasColumnType("bit");

                    b.Property<bool?>("Guard")
                        .HasColumnType("bit");

                    b.Property<int?>("HallCounts")
                        .HasColumnType("int");

                    b.Property<float?>("HoldArea")
                        .HasColumnType("real");

                    b.Property<string>("JuniorHighSchool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandSection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Leader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LetterNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LightingFace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MRTStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("MainArea")
                        .HasColumnType("real");

                    b.Property<int?>("MainMaterial")
                        .HasColumnType("int");

                    b.Property<float?>("ManagementFee")
                        .HasColumnType("real");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Market")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NeiborCounts")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("OtherArea")
                        .HasColumnType("real");

                    b.Property<string>("OtherAreaDefine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherMainMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherOutsideMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherPropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherUse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OutsideMaterial")
                        .HasColumnType("int");

                    b.Property<string>("Park")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Parking")
                        .HasColumnType("bit");

                    b.Property<float?>("ParkingArea")
                        .HasColumnType("real");

                    b.Property<int?>("ParkingEntrance")
                        .HasColumnType("int");

                    b.Property<float?>("ParkingFee")
                        .HasColumnType("real");

                    b.Property<float?>("ParkingPrice")
                        .HasColumnType("real");

                    b.Property<int?>("ParkingType")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropertyType")
                        .HasColumnType("int");

                    b.Property<float?>("Rent")
                        .HasColumnType("real");

                    b.Property<DateTime?>("RentPeriodFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RentPeriodTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoadWidth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomCounts")
                        .HasColumnType("int");

                    b.Property<string>("Sales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("SellingPrice")
                        .HasColumnType("real");

                    b.Property<float?>("SettingPrice")
                        .HasColumnType("real");

                    b.Property<float?>("SharedArea")
                        .HasColumnType("real");

                    b.Property<string>("SitDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ToliteCounts")
                        .HasColumnType("int");

                    b.Property<float?>("TotalArea")
                        .HasColumnType("real");

                    b.Property<int?>("UnderGroundFloors")
                        .HasColumnType("int");

                    b.Property<float?>("UnitPrice")
                        .HasColumnType("real");

                    b.Property<string>("UpdateId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpperGroundFloors")
                        .HasColumnType("int");

                    b.Property<int?>("Use")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Property");
                });
#pragma warning restore 612, 618
        }
    }
}
