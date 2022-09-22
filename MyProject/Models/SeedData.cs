using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.Models
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("test@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test@gmail.com",
                    Email = "test@gmail.com",
                    NormalizedUserName = "TEST@GMAIL.COM",
                    NormalizedEmail = "TEST@GMAIL.COM"
                };

                var password = "123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "管理者").Wait();
                }
            }

            if (userManager.FindByNameAsync("test1@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test1@gmail.com",
                    Email = "test1@gmail.com",
                    NormalizedUserName = "TEST1@GMAIL.COM",
                    NormalizedEmail = "TEST1@GMAIL.COM"
                };

                var password = "123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "組長").Wait();
                }
            }

            if (userManager.FindByNameAsync("test2@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test2@gmail.com",
                    Email = "test2@gmail.com",
                    NormalizedUserName = "TEST2@GMAIL.COM",
                    NormalizedEmail = "TEST2@GMAIL.COM"
                };

                var password = "123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "員工").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("管理者").Result)
            {
                var role = new IdentityRole
                {
                    Name = "管理者"
                };

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("組長").Result)
            {
                var role = new IdentityRole
                {
                    Name = "組長"
                };

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("員工").Result)
            {
                var role = new IdentityRole
                {
                    Name = "員工"
                };

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("秘書").Result)
            {
                var role = new IdentityRole
                {
                    Name = "秘書"
                };

                roleManager.CreateAsync(role).Wait();
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyProjectContext>>()))
            {
                if (!context.House.Any())
                {
                    context.House.AddRange(
                        new House
                        {
                            City = "新北市",
                            Region = "泰山區",
                            Section = "泰山段",
                            Subsection = "二小段",
                            Number = "0139-0000",
                            RegisterReason = 0,
                            Order = 1,
                            Area = 1.23F,
                            OwnerId = "88",
                            RegisterTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            CreateTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            CreateId = "99",
                            UpdateTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            UpdateId = "99"
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Department.Any())
                {
                    context.Department.AddRange(
                        new Department
                        {
                            Name = "土城業務部",
                            CreateTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            CreateId = "99"
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Owner.Any())
                {
                    context.Owner.AddRange(
                        new Owner
                        {
                            Name = "老王",
                            IdNumber = "A123456789",
                            Telephone = "0912345678",
                            Phone = "0234567890",
                            Residence = "台北市大安森林公園涼亭",
                            CreateTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            CreateId = "99"
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Property.Any())
                {
                    context.Property.AddRange(
                        new Property
                        {
                            CaseName = "帝寶",
                            LetterNumber = "001",
                            SellingPrice = 999.5f,
                            Address = "台北市仁愛路1號",
                            PropertyType = (PropertyType)1,
                            OtherPropertyType = null,
                            Use = (Use)1,
                            OtherUse = null,
                            TotalArea = 39.5f,
                            MainArea = 20f,
                            AttachedArea = 5f,
                            SharedArea = 5f,
                            OtherArea = 10f,
                            OtherAreaDefine = "狗屋",
                            SettingPrice = 1200f,
                            HoldArea = 12.5f,
                            LandSection = "某某區",
                            BuildingFinishedDate = new DateTime(2012, 12, 25),
                            UnitPrice = 59.5f,
                            Decorate = "簡約",
                            GasFacility = "櫻花",
                            Balcony = "露天",
                            BuildingName = "陶淵隱園",
                            UpperGroundFloors = 25,
                            UnderGroundFloors = 5,
                            SitDirection = "東南",
                            FaceDirection = "西北",
                            RoadWidth = "5公尺",
                            LightingFace = "南南東",
                            RoomCounts = 18,
                            HallCounts = 5,
                            ToliteCounts = 7,
                            NeiborCounts = 2,
                            ElevatorCounts = 3,
                            ElementarySchool = "仁愛國小",
                            JuniorHighSchool = "忠孝國中",
                            Park = "信義公園",
                            Market = "和平市場",
                            BusStation = "仁愛一",
                            MRTStation = "市政府",
                            Status = (Status)4,
                            Rent = 300000,
                            RentPeriodFrom = new DateTime(2021, 1, 1),
                            RentPeriodTo = new DateTime(2022, 12, 31),
                            MainMaterial = (MainMaterial)4,
                            OtherMainMaterial = "奈米碳管",
                            OutsideMaterial = (OutsideMaterial)1,
                            OtherOutsideMaterial = null,
                            Courtyard = true,
                            Guard = true,
                            ManagementFee = 18000,
                            Parking = true,
                            ParkingArea = 19.5f,
                            Floor = "B2",
                            Number = "789",
                            ParkingFee = 180000f,
                            ParkingPrice = 590,
                            ParkingEntrance = (ParkingEntrance)1,
                            ParkingType = (ParkingType)1,
                            BringingType = (BringingType)1,
                            GiftPillar = true,
                            GiftWallCabinet = false,
                            GiftLiquorCabinet = true,
                            GiftPhone = true,
                            GiftSofa = false,
                            GiftHeater = true,
                            GiftBedding = false,
                            GiftCooker = true,
                            GiftGas = false,
                            GiftTV = 0,
                            GiftFridge = 1,
                            GiftAirCon = 2,
                            GiftOther = "噴水池",
                            Feature = "奢華",
                            Note = "賣不掉加價賣",
                            Leader = "王大明",
                            Manager = "老闆",
                            Sales = "陳美美",
                            Phone = "0911222333",
                            CaseNumber = "12345",
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
