using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using System.Configuration;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;

namespace MyProject.Models
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("test").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test",
                    Email = "test@gmail.com",
                    NormalizedUserName = "TEST",
                    NormalizedEmail = "TEST@GMAIL.COM",
                    CnName = "老闆"
                };

                var password = "123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "管理者").Wait();
                }
            }

            if (userManager.FindByNameAsync("test1").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test1",
                    Email = "test1@gmail.com",
                    NormalizedUserName = "TEST1",
                    NormalizedEmail = "TEST1@GMAIL.COM",
                    CnName = "陳小美"
                };

                var password = "123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "組長").Wait();
                }
            }

            if (userManager.FindByNameAsync("test2").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test2",
                    Email = "test2@gmail.com",
                    NormalizedUserName = "TEST2",
                    NormalizedEmail = "TEST2@GMAIL.COM",
                    CnName = "王大明"
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
                if (!context.Owner.Any())
                {
                    context.Owner.AddRange(
                        new Owner
                        {
                            Name = "老王",
                            IdNumber = "A123456789",
                            Telephone = "0912345678",
                            Phone = "0234567890",
                            Residence = "台北市大安森林公園涼亭"
                        }
                    );

                    context.SaveChanges();
                }

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
                            OwnerId = context.Owner.FirstOrDefault(x => x.Name == "老王").Id,
                            RegisterTime = Convert.ToDateTime("2022-01-01 00:00:00")
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Department.Any())
                {
                    context.Department.AddRange(
                        new Department
                        {
                            Name = "土城業務部"
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

                if (!context.RealEstateDetail.Any())
                {
                    context.RealEstateDetail.AddRange(
                        new RealEstateDetail
                        {
                            ObjectName = "高級農田",
                            City = "台北市",
                            Region = "大安區",
                            Section = "仁愛路",
                            Subsection = "一段",
                            PlaceNumber = "234號",
                            Area = 123.45f,
                            RightsScope = 123,
                            AppendicesNames = "就是附件",
                            IsLandOwner = true,
                            LandOwner = "王大媽",
                            IsOtherObligee = true,
                            OtherObligee = "金貝貝",
                            IsRegisteredManager = true,
                            RegisteredManager = "錢夫人",
                            IsOwnership = true,
                            OwnershipType = (OwnershipType)1,
                            IsOtherRights = true,
                            OtherRightsType = "1,2",
                            IsTrust = true,
                            TrustContent = "哈哈",
                            IsBaseRightsSettingBurden = true,
                            BaseRightsSettingBurdenStatus = "哈哈",
                            IsSettingOtherRights = true,
                            SettingOtherRightsType = "1,2",
                            IsRestrictingRegistration = true,
                            RestrictingRegistrationType = "1,2",
                            OtherRestrictingRegistration = "哈哈",
                            IsOtherBaseRightsItemBy254 = true,
                            OtherBaseRightsItemBy254 = "哈哈",
                            IsOtherBaseRightsItemRelated = true,
                            OtherBaseRightsItemRelated = "哈哈",
                            IsUseByConvention = true,
                            UseByConventionContent = "哈哈",
                            IsRespectivelyManage = true,
                            IsRespectivelyManageBy826 = true,
                            RespectivelyManageBy826Type = "1,2",
                            RespectivelyManageBy826Content = "哈哈",
                            IsRent = false,
                            IsLend = false,
                            RentLendStatus = "哈哈",
                            IsOccupiedWithoutRights = false,
                            OccupiedWithoutRightsStatus = "哈哈",
                            IsPublicWay = false,
                            PublicWayPlaceAppendice = "哈哈",
                            PublicWayArea = 123.45f,
                            UrbanLandSection = "哈哈",
                            NonUrbanLandSection = "哈哈",
                            NonUrbanLandType = "哈哈",
                            UnKnownLandRegulationStatus = "哈哈",
                            BuildRate = 123.45f,
                            VolumeRate = 123.45f,
                            IsUrbanPlanningManual = true,
                            DevelopMethodRestrictionsType = "1,2",
                            OtherDevelopMethodRestriction = "哈哈",
                            IsBuildingRestrictedRegion = false,
                            IsFarmLand = false,
                            BuildFarmhouseType = "1,2",
                            FarmLandRegulation = "哈哈",
                            IsMountLand = false,
                            MountLandRestrictions = "哈哈",
                            IsBanningBuildByKeepSoilLaw = false,
                            BanningBuildByKeepSoilLawRestrictions = "哈哈",
                            IsRiverRegion = false,
                            RiverRegionRestrictions = "哈哈",
                            IsDrainFacilityRegion = false,
                            DrainFacilityRegionRestrictions = "哈哈",
                            IsNationalPark = false,
                            NationalParkType = "1,2",
                            NationalParkRestrictions = "哈哈",
                            IsDrinkingWaterSource = false,
                            DrinkingWaterSourceType = "1,2",
                            DrinkingWaterSourceRestrictions = "哈哈",
                            IsWaterProtectionAreaByLaw = false,
                            WaterProtectionAreaByLawRestrictions = "哈哈",
                            IsPolutedArea = false,
                            PolutedAreaType = "1,2",
                            PolutedAreaRestrictions = "哈哈",
                            TransactionType = (TransactionType)1,
                            TransactionPrice = 123.45f,
                            PaymentMethod = "哈哈",
                            IsLandValueAddedTax = false,
                            LandValueAddedTax = 123.45f,
                            IsLandTax = false,
                            LandTax = 123.45f,
                            IsStampDuty = false,
                            StampDuty = 123.45f,
                            IsOtherTax = false,
                            OtherTax = "哈哈",
                            IsConstructionBenefitFee = false,
                            ConstructionBenefitFee = 123.45f,
                            IsRegistrationFee = false,
                            RegistrationFee = 123.45f,
                            IsSurveyFee = false,
                            SurveyFee = 123.45f,
                            IsOtherProcessingFee = false,
                            OtherProcessingFee = "1000萬",
                            IsContractFee = false,
                            ContractFee = 123.45f,
                            IsOwnershipTransferAgencyFee = false,
                            OwnershipTransferAgencyFee = 123.45f,
                            IsOtherFee = false,
                            OtherFee = "哈哈",
                            ChooseManageType = "1,2",
                            ManageMethod = "哈哈",
                            IsBreachOfContractPunishment = false,
                            BreachOfContractPunishment = "哈哈",
                            OtherTransactionItem = "哈哈",
                            SurroundingsAppendiceType = "1,2",
                            Surroundings = "1,2",
                            IsCadastralMapRetest = false,
                            IsCadastralMapRetestAnnouced = false,
                            IsOutOfBoundsBuilding = false,
                            OutOfBoundsBuildingStatus = "哈哈",
                            IsCompulsoryAcquisition = false,
                            CompulsoryAcquisitionArea = "哈哈",
                            IsElectricityPower = false,
                            IsTapWater = false,
                            IsGas = false,
                            IsDrainer = false,
                            NonInfrastructureReason = "哈哈",
                            RealEstateBroker = "哈哈",
                            ContractDate = new DateTime(2021, 1, 1)
                        }
                    );
                }

                if (!context.CaseSource.Any())
                {
                    context.CaseSource.AddRange(
                        new CaseSource
                        {
                            CaseName = "哈哈",
                            TotalPrice = 0.1f,
                            UnitPrice = 0.1f,
                            Section = "哈哈",
                            Subsection = "哈哈",
                            PlaceNumber = "123",
                            LandCount = 1,
                            TotalAreaInSquareMeter = 0.1f,
                            TotalAreaInPing = 0.1f,
                            BuildRate = 0.1f,
                            VolumeRate = 0.1f,
                            Hold = "哈哈",
                            SellingAreaInSquareMeter = 0.1f,
                            SellingAreaInPing = 0.1f,
                            UseSection = "哈哈",
                            UseStatus = "哈哈",
                            Environment = "哈哈",
                            Feature = "哈哈",
                            IsCadastralMap = true,
                            IsAerialPhoto = true,
                            IsTranscript = true,
                            IsUseSection = true,
                            IsUrbanPlanningManual = true,
                            IsCurrentPhotos = true,
                            ValueAddedTax = 0.1f,
                            Other = "哈哈",
                            Agent = "哈哈",
                            Phone = "哈哈",
                            LandInventories = JsonConvert.SerializeObject(
                                new List<Items.LandInventoryItem>()
                                {
                                    new Items.LandInventoryItem()
                                    {
                                        SectionName = "haha",
                                        PlaceNumber = "haha",
                                        AreaInSquareMeter = 0.1f,
                                        AreaInPing = 0.1f,
                                        Hold = "haha",
                                        HoldAreaInSquareMeter = 0.1f,
                                        HoldAreaInPing = 0.1f,
                                        PresentValue = 0.1f,
                                        UseSection = "haha",
                                        Note = "haha"
                                    }
                                }
                            ),
                            AppendixItems = new List<Items.AppendixItem>()
                            {
                                new Items.AppendixItem()
                                {
                                    Name = "圖片一",
                                    Format = "png",
                                    Base64 = "iVBORw0KGgoAAAANSUhEUgAAAUEAAABMCAYAAADz5wVbAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiUAABYlAUlSJPAAAGeRSURBVHhe7b0FYB3HuTb8iJlZsmQGmdmOKYkdZm7SFG65Sfu1vb29vb1l+sqQpmmTFMNMdjiOE8cUM7Ms2wKLmaVzdPQ/z+zu0dHxkSxT0v6fHnu0s7uD78w8876zs3uCegh80FCOQZa3j9+GihQU1HvR/3wIQxjCEM4VPhwSHMIQhjCEfxEE28d/D4iuxdkeOpu6hzh8CEMYwtng30cTFPG5uoG6Brjr6tCVkoiI9BSEBIeY26qFLGZVxmtp8+KQGT2EIQxhIPwLkqBNYzqoaG4SX2s7UFaJmp278f7q91BaVo7QOVOQu2Ae8sePR2pqKiIjIxEcTMWWpDdEe0MYwhAGiw+RBJ1sfSnLMB//81q3B2huQcvBI6h5732UvbcejVt3oqyThJiXg+rZ+TiRFIP05FSMGzfOuLy8PMTHxyM0NHRIAxzCEIYwKHwIJGhl10uBPmQl4utyAVX1cO3ah70r38axjVvQXlKOkOZWxFArbIwMh2dEDipnT0RpYjSCGCc4KBgxMdHIycnBpMmTSYjjkZyUhNCwITIcwhCGMDA+RBK0yMn81SUVo6Ia1es3YecLL6PovQ2Iqm9EHC+HItgbri4yFN02CZ4gCQbzWpDi86a7m6YzQ2ZmZmLW7NmYOnUq0tNSERxirRsOYQhDGII/PvQ1QWUvEvPU1OPg3x/BoQf+jnZqgtEIIfkFkf54U0RnAlsk6B4uc5gkmGSRoLlvK3yqjbvbzfBBZq1w0uRJyJ84EVlZWdQWYxBCQhzSDocwhCE4+NC3yBhCInP1dHWhvaYWoY2tiO0JQgTJLFiMJpI7CQzvc8NOwjghNCQUIcHBqKmpwXur38NTTz6JF194EVs2b0ZVZSW6Ort6Aw9hCEP4fxofKgn6KqHSzUKDQxASZG95MX/7wqvA2R5vmH4CS+sLCQlGY0Mjdu/aiRXLV+DJJ57E6nffRVlZGbpIvB+yIjyEIQzhQ8aHQIIiHYt4TjJLvXwUFFBR816jRzGd2CcHpTEcpO0y8tKkplaoc5He8ePH8fKKFbj//vvxyssvo6ioCJ2dnUNkOIQh/D+KsyPBQLyha3rK29YJnKhCw9ZdqDh0GF2trX5EMzDpDLhuZ+4NcJ/oj9SkHYZHRKClqRmrV6/GP/7xDzz7zLPYsWMHaqpr/kW1w7Mtj+I7bghDCIQPt298GLk7S2ohPySM73ThW2qHj8xbHW50l1WiYt1GHPznE1j37AvYV1qMNk83wmNjEB0dQ81MJq8PiZF0elpaUbVxK5p37IbH7SY79yU556w9NBiexHi05aShKTLMXO8bcnAIonaot006OtqNaVx4pBClJ0rR2tZm9hlGkCg/8Ico/jI15/xjPf6WmLzl0RU1Yp8tRlYwwgS0/Q68Nwlq2l7fOYR/olaB7ZNzAKWv5M51uh8mHJkJp1klSwxOAmcU2TmxnXAe5aos/JI3CgfLMVDufe7pRHGkaIlv9ILEGcAiQGv8nN3TYSemCtTeAZSUo27N+9j15kqU796Lrpo6tCbHo+GCqejKSEXWuHG4/IorMHz4cOvtDgeM7ymvwp57HsCJvz8Gd3un2RbjC0cA5unwCOvpsPYJ9m6RGRi+wg0UXGLQPz1USU5OxoT8CZgxYyayc7IRFkay/aAGnQonWVZWAzX1esoDpKcAqUlAeBhvWuUwdbDLFKStQY0tQEUV0NwOJMSYDeWIjGAnURjfGp/jeqj7OG/11DcBTSxHfDSQlWGV1+RvQ8U4KXurbH50HhgK6mFfU39zzgX/Kg4G9uALDN/EGEbhQtgfQ7RMw5L2iedbiFNAQRnMHPRH9aiuYzvXsp0pK7VzUnwfmfnmZ0c3GLD4gaDIkl0r+1aX20oggnnGRtn2oAKcglAUhGPT9E/FDwsFYhhfW9DOlIxNosIp4lFWPbTe3IVFCC6vRktri3ltNnLRPJZD+avsgdM6uc0cKPzZkKAa0E3X0gYcL8axdRuw46VX0bhzHyI5IOKYqXbt1WYko3rRdDSnJiIiNRXXXX89Jk2aZLQtL86QBJ19gt66DwBfEfgGl3D8ReAhqWibTXRMLCZPnoRZs2ZhWG6u2WJjrS+eosEGi/5Ef6wEq/72EHY+9xLikxIx7Y5bMZcO6cm86Ze3Ttmxy9ZuwOq//BNtew4ics40fOyn3ycRDrMGrz8GWf4+nUdlld8pspMEz3uqarB3xWs4/Pa76OZEGDdjMq788l3AmBFWB3XiBoSVoEhQ6C+U0EMLoYuDoGrHLnjUR5Ssc88+6tzXL/if++LksLxi11sbtLroD4mPRcrkfESOHYEg335rYIU3E0EbyUE7D5SakZWTOmHqz/PIcCCaxKFB29SKY088hzcff5JNm4Kln/4EEpcutkmFwQ3x2vLTeBOJ9QEDiTA1UcopTgCYduwJQkddPY6+thKNO/aik2UZNnMqxtx+M9vIIZB+EhBUBNatftN2FLKdm5sakTFuLKZ85CYgJdEn6gBp+EOanCZw1U9viRnoqLL4gW3fdvQYNtz/Dxx5+U10tDQhe8pEXPeT77K/z/Lp56eoh26pLSRXe7I5MxJUlJoGNG7bhcqVq1G8Zj0aDx1BUKcL4UEhTNuqiJuVrM1IQpVIkIKKzkzHtdddh4kTJxpT04szIcFZffcJDgZWqRzQZy5YgnDg9FWTbI+Hsu9GfHwcRowcSe0wH2PGjEFaWlrf8p8KSszOxqSrvy7OxqYDeG8RogJeOHQc6//4IA4+8zyi4mKR/6mPY8ZnPglkp7HfOHRhQWkFt3aihu2w5p4/wbNjD3oWzsGt9/wKGJWHHg0OH6i6Wgowg5nHPkTnA9Vd7Wzdce6r9GoXnctvo6IaB/72CDb9/SHElVXBM3Y0Ft/9eWR+8nZL0+jTxeSX802Tf+0yWAf9ce7bYBoeaiA1zyzHul/8Hp3UBiK7nbSMRL2xrBRPhnPPCeuL3nOlZaUkEmyjN3JELhZ87YvI+OgNCIqKNPf6gH3EXXICB559Aa5tO9n/JXMrDZVb+XmoKQVxQohfvABjrr+aGl8Suvcfwtpv/QTHOIGlJCdh3KUXI2HmdDYLCYuEF0RNJ2/uHKChEUe370AUx4XGliNOF1P26E2pOTMQmj/GGtQBKmfamM3ZVlSKLT/6JSqfexktDDvppmsx7/7fkZRlYfQiYJ/gWHY3t6Ds4Wew5ff3o7aqAiMXX4BL//xbYAQn29M1S1VOKlAtBw+jgxZjuL1E5khfMFUx9WUfp9/jdqFl0w7sefpFtJw4AQ/7cO7lyzD/tpvRHhcFtyMYE1PpWCmZFrDrI8UsjOM5Nn8cLZY4I6szI0F2vvrXV2HF//01ug8eQXyHC5GmoNZKnkmQnj4kmJqA6IyMwCRIjdJDU+58aoK9sITRG4mi4iWHXOS8d3gi6fSwQ+p+FGfwuXPnYumyZUhISLBDnSaYTk9rGxq2bEf93gMIoyx9LQlDMZV1KODAqNi2A+FRUcicNwejF8yDKzHGaKkWFMlQJqKZRt3BAhxetQae0nKSXy7m3nw9glOS0GlmOzsD5t3FGTNuWDbSFs6nZplqVdiBglED9hwvRd2+g/A0NyNcAUx0Ow2rhHQ6tzpadBc7JyfBnS+/jtaCo+yQMRhxwTxMueEqdJEEe8usuIynCnsnHytd/XVxokyZNgUhnCx7WE7foqns3R0dqH/yJbz/89+hlcQbm5iIkNxseKIi2CWlJflXpjcP9ZMQnkewT4YxLRflIp2tm8cQNnQky+NmGi7Q7JKWRq3HQ9Joqq1H7IjhuODrdyP1YzciKJIkaA8oL2heth84jFU//RUaX30bbpbdSpvpMK9w5q2ah4eHIeeOm7D4619GcGQ0jj71HLb87s9UKOoQFB6O7phIdFFTDGVZutVPUpNw2+c+i06a4Q/94Y+IZ7+himHEF6q2ZL2CMtJwyVfvRs7tN/hoQwHAMdZBot71k9+i+pkVaGLQiTdfh+l/4mQZTe3UAdM1Gi3zMpqaJku2p47ulhZUPfoctv/2z6itrMCYixZh4R9/CYw8AxJk2l2Fx/Hur3+H0s3bERPCMvCaerQjXbWouokhMf7X9Zh2tktVPTwd7ea+i2ULT02GOzzUnJupi3WwSsNJgn89Jg0LnfRnTBiHZd/+b4RPHG8a5sxIkAJtfux5LP/OjxFd24hollQZ9QHPXRyctZlJNIenGXNYJHjNtdcaEjwX5vDprAn2wiqoRR9K0jrv0UzNS8pVd/yTlJg0K02fMR1XXX01UlJS7DunCTa0q7Ia235/H3Y/+RzCSSAhbClTDpMHZypyRqirG5EMq3w7qc25qEW4OBhMSLvJLB7hIKacwyjDcJeHg1wPjzjAaeJoEFrt4tS1B+3sLCNJqhd//1sImzqRFTYBLDBYd3sbql56A2vufQBtxSWmDB5KxXRE4yQhxVH30rk6Ha9yogiTJcAydPO2OzQYrogwdGtgSg1hGNM17caSeaZUTF1IPvJ3TxqPy77zTaQvWYCecFGWDxjOTRJseOolbPjZb9FYU49pF12IqV/+HJCbxc7mssIZgjKZ6UR/CPu8oQnl729GR/EJROTlIJsTC2jqguZ8C7WyNpYjfeokTg4Z1G4rsJ1ttOvt1UimFbDgPwcmQdeBAqz98a/QtuItBHNyGUYyj8vNIXF3ovFwIYoPHjITSu6nbsfU//M5auz78OJvfo/m3fuQnJCE6OwshLONRfQdpRVw01RuYTtOv3Qphs2fjbWrViGMmlg0G7S7qQXNpWVoc3Wha1gWLv3OfyH9E7cNTILsI52s986f/AZV1KabpAnecj2m3/cLmwStOvWwLpqgd654laTXhvi8Ycin5ho/ZhTcba2oeuQ5bCNx15WTBC9e7EOCPjIxbcqjucQ/fuIyYHk8hcew5qe/QPG6jUiKiEEENWpPSyvcJODoiAhE0ArSurL6Uxf7lyYpqy+qX3MEm6Q1HjzkC5gXLLQrpb2xEW5aWpo8tPQQadZZLauH1I7MSfm48AffRtBkkiB1sQGkdgqoI6gg9FqDMTDsrm6EYuTCOIHMrw8OohuVxIJdA2ds+tzp9Tmwin2WZZfM2CDBsXEIpgkUTJNHZk9oWipC0tMQTFM7LDmRg83SbjzsXEE0ecJSkhGiMKl0DBOcmmL7UxGm6wnx6OEgkhnbw44TlpxsrocyTYU3LpWO5B2clGjCnFxHS2MKJwFHsDOFN7YhvLULIRwYISRmcZk+WKEHMUEy1zRzszNrrYq5wk3Sa6c208lB5Y4I5RWW3YQXSZKsGT6Y4YN5TS6UfuUV2e5GVFMnItpdCGVaGkSOlL1ztC4Yx3M6D0k2iHU2phjNVYwfDUygGz+q1z9Bfvt87Ei4ORj2bdyMTQ89gd3rNgCKn52JwgP78c79f8WGp59F49FjAOWvB0seahndzixLN1C/tUvJOY71JSlP/ezHMfIXP8CYH/4PMudMQyOFF5KUgGy2Q1dBITY+/Dia9xxARHo6pn7qTlzy519jyZ9+i1lfuxvhrI8Zv1Q2Du7YiRpOTFf93x9i2V/uwcIffguZF8xBexiVgbAwJE3OR/J4mnY+ZTs9vcYRLMFoPbQEOmhVHH92OY48/CSOvfAKOk9UGNIyYFBjovIYMBe2sdEkqd3q259mrTRQQPbr4OxszP3v/8R1Dz1o6nbJj76NnPlzOIGHMUowwqJjkJCXR43zIiz+/GdwxQ+/i6t+/3Nc9cBvcflfGf5vfzDu6gfvwRW/+BFm0CyOy0hHB8vWGR2B2AsX4OJf/xhX/OPPWPq3P2IZ3ZV0c7/33wgameNlP/9V3tOGI8KAAiEsDcJIzhH1OYOT96CgIvDgO0mZxtQZ/5t0+Ke3/5gr5wXhiQnmQcesi5cghIPGKFXe+YgFKC7H1udeRMHKd8x3EvOvWIaJ114FpNAEVyezasKD/IzX6Ub9lm3Y/NTz6DxUiOjhubjyP7/MAU6NxneGZrxujq6QhDiAJrEzcIyWa3wWjOkoQXjciM7KwNhrrkQCB6aLWSmsFVp5W1DYUJYrjJf0vrdm4C7mqxAmVG9QwrkahLjgMDTtO4CNL7yM0I5mmnjSCL2xDLzE41y2G0ika0xgyUMDze321icgSCihHJzhIneauvoqEWo5SDlohlETKwoOQRE1k2PUSqbPnEkGirTqatKkYzb+cjoZVtlcMocjwo1mh852VFWUG3JJ1kRWXYvNf3sER0jGkbGxmMI+kJCShKrN25CenYNGmojN9Q3mox9626mloRFHWKaRs2cjeMYkNK/fisJtO9HG9BJGj8DMW29AqDR6n4IFJGuraAHgG5b1Yx0jeS1WExTFmsA2CrP7pglp0vGOaqvvUvtHZ6fRqF3HS1C2Zx8O7NmLmCkTsPiL1NSNNdCbj4mrU06Y0RMn0JLkla4uNPNiTU4aOsaOQHtVHYrrahHc1ICIEyWI2bkDcVQaRHJpw4cjY9RIRFMJUNHaikpQQHmWUqvurKpGcP4Y5C+7CPk3Xgto7Y9tEWYytIUgr87tIp3ZPkF2vC7OYofeeQ9h7FjarWcn3wtmoGsdcdFozctEV1QEQtno48ePNw8W+myRUWfrs0+wm3WzS2jDOfPuE8xKQ3OUtU8wMDiXBDEVNoDKoTU9wZeKdcWnbfogUEfStczMLIwdNxbR0dH21dMEkzXrXdICacogI80iK2okyOFRLjgUJfv2o+rAAQRTbqmLL0D6VZeyQanVZKUzjBOW8RWP8nQ1NODoth3oKa9C99jhmPCJjwCT2AFyFc4Oz/yCh1NzymYa1AQ1wNWdrQdZdn1pRrTvP4wimo1tdXWIHpWHCXd/GsnXXobY2VMQO2sa4mZN5XGqOcbPmoJ4DsJQaqbFLU3wxMcg/oJZSL7wAsTNnm6Hm8ZwikMT0Y6ndKKmTUY089uxZh0iaOr1sE1HLF2EqBHDyaY+a8Y29HS4Y+9BlKx7H+00M/PGjUM6zbTD6zfg+GtvonbTdlRu3ILKTXQcFJXsT+ac/rr3t6Bk01bU7dxrHjS42Tc8LS1oLChAFU3VlmNF6OT1kPZO88AhJjIKTXv2o5RaUQxJMo/aV/TUfOuBkn/fIGF019Sg+L316OIk1EM5j1u8ECHUJpt27cHh51egU9tg2Ocbi4pRRZLQov6C667FCJq67654GcepcdVt3o4ylq+FGlTumNEYQbNNbzTpIaS7sQn1NNEPMK22fYeMyT2bE+mw228kU9Fs7DPZ+UD93hoACGpoQcWaDcb071Rfzp+AjCvZryRrhVMSJNf2PQdRuHo9uls7OAlmInfZEkTSLO7pdqFt135Uvr8V7Ryv6WynYQsvQNvxYhRS/gWchAseexYnXn8HzSxjDPvmiEuWWunb5bNGod3b9EfX5Uj6EdTMcybmY9zsWRgxZQpyR41iF89Eclg4uqmNtu05hOa9h1C9ZSeOvbcBxavX4fjK1Sh8c5V5KcNFGeWSX2Z/7hMYdgflwr4rAjTrlSYPOy85nzY8CxI8SBJcw9m1kyQYAMxDGnRHbBRJMAOdZP0wkuA4FjL9XJAgZ4xme7P0yaBpxgGTRKKZO28+UmgWtne0w03Tq5uN7JgLAWdMg8DXzwkJEiZ1yrCVA/rd7/4Yxx95hubHyzj23HK6FSh95S3U79qHkKZWsz7Yyg5QsWY9Cl96FccY7vizKxiO4c2R4Z9fjpJ316CTM6JMV09bG2qoLRSteAOFvK90D1Hbqlq7iQM6HhE52ZwctBHcp6aOLEhKHQcKUELy6KwlCVITHHHFJYgYkWcW70UCcsG2C6KmgNpmHKfptObeB1Gxai2Ki4uRwM4bR1MmiJ3QidPrqFvwKPQcOY491HjDWVdkigSXkATZefshwU7KrHjt+7S4ujBmQj4Sad6/+/jTKKQMKkl0ZRvkNqPcHLeg3FzbjDLWp2bXXgTVNxqN1cX+VrJ7L4p4vYrXu+saaZ570EIzrqKpEVmZnDSqa1B48CBllohckmAMSdA8KPDvN4zXTZJzSDCIJDieJBjMCa7g9bdwePlriImLhycjA5X1dehi/EnU4PK/ehdCxoxEe109qkhMDaUn4Ka/m+b00v/zRaReejEOk6C7ik+guagUZdt3oLWMpmlUJPJuvAaTv/wFToBJlqYVCFpaIKmjTvs32xBcUYP6tRvQVHCMIyQI2SSx1AvmWmFkwqpeTKqDY/s4w3W3tiEqk5oySTCKhC75t+3ejwqSoO6Fsg1qSdq7n3kJx994G42M56muQxC1OjeJJmH6JAy/5GJrm5SIh9BfP+lZUN40g0NoJYVlZCJ6zBgkcJLUemwax20b26WTbefSG13kh66ODjQ1NqCBk7/WivWAMVQPtNh/WyoqUU8SDqusRVQ0J4iIKCsPuwz+7XeWJChNsN1ogieBlxjMrBFJE+ykeSESlCZ4Tkgwe6A3RoLM1pbExCRcetmlWLhwISZPmYz09HRDXtIQg9mgIcZZeTlbNHoRIFWGORckaNKmcJppfr334D9Qf/AI6kvL0EISa+e1tlKaT60k7chwU98mLUiXl6O25ATajxWbp2ptR4s5MEpQU1aG6rJyNNTXw0U5dmmtj1pSCwdOE7WbBoapZtzKE2Xo6uxA5gxqb+NGk4jYMX2q6CgC6uhayD9E87qBnSxcszkHY9SwHGuwSU6O01zCSbCes/Gevz2GLpYvhtLMnDcT+VddRg0lDj3seGayCeQ0RlnfzSTw7vYOdFNbHXnxYsSIBAMMbJWtnSRYamuCw9gOqdMmoZJmUxC1lCQSbyyJJpYmk8wmHeVidExPQxTN0WC2t+SjjeSJw7IRPzIPYRzoYaxnGAk/nP648WOpUYyj/I6j6OBhxLIf5c4fDAmuMySoBzX5ixdw8EXiwIpX0LT3ALInT8KcT38cudOnYtTsGRg/ZxaO7tiBeJrh2ZOnIo8kVVxwxEwOw66+DCPuvBUYNwqp0VEo3r4LPdRyoklWwRERmHTRYkz/yhfNLgCwfwToqlaD0lWs34gV3/o+tv/1nzjw8qtooJYfqvqz8arLK7D3tdex8ZnncHjVaiTRLI+jid1JjesoCd1Dokug7MYtugAhcQkIPl6Kek4o1Tv3oIdl0YOT6pJStFOD1uQWHRNtnrT3kIi0ZhvHtsnzI8GAoPy0yd5DU7p9Byemle9izzPPY+cTT2HHcy9g/4ZNqGQfbyUBtoWHoouaryaanHmzMIGTpnY5NDG/VmZT39qK8uISnNh/EAW0CPa9uRJH165DG8kymhZXpB62+LXfWawJagTIBYYzqKy/pJkeq1MPIIpzCtVTDwm6RXIk3NSUVM56qZgxaybqabpUHz6C9ymgEhJFeFwcurUGZBqKc6SJ23/dzhrKhpnEZWdhwSfvpMbXws4TjJDySpSw8zXSpA1jh8peOBuZUyehlZ1KH4DQVpMWDoiaLdvR1d6FRA76vMuX0bROgNvTbcK4OTu3UAtUR+1kp8mbNBHDLrsQjUE08djJU8aOQrDMAtN2piB0lrzUaMEkxzgSw4QrL0EL804YnosomroBG06dlzPuVppBrRz8UZRh1szpmKb1S5q2IjJH2/aVpjcpyjuS5DrluqsRQU0sKC/L7CV1BowTxz9r0zR07VoTzB+NpQu/hTaatuYZhlQZB3YnlNYTTtm0Ucs6eN/fUfL8y+jOSsfsuz6L5OsvQ6fYmP2kg4NZk2MciVQ/7VCw6h2zRmZlaLI8qSzmonXbhseSpbYF0Zwu2rTNvKseOToPkYtmI5n19VRX4wgnjY0PP4FDmZkYP3IUKtgf25nQaA7smR+hKadlDGrrGVcsxXxOipv+8Qh6SivQExWBoDS2RxQnO41eUz+nXFZhVF9zzok2vLEF0QcK0c244SyYXllVm4R7guCpb0JobQP7PRAzrBlR0hhtKCWjHDQ0oWQVLb43V6OYBNhEgulhf9U2Iw/bN4GTS8KkCUiYMw0jk1Ox642VOM5JSmQYKlNUKZ0kND90utBMM3vr/X9H55qNnBBJ0mwPKSkxjB/MCSs8IxWxJOgYTuBJUyYhbfpkTsxZRiseTU2wrboWrdRw6ynzZioV8rceL0Lb/iPoKa9G+OjRoOQcEfWCl07SBHW/d4Wvn9IbTbDvmmBfWBXXOlwbzeE2rQlGsyIxMRg/YTxS+9UEtxhNUOqu2SBhnsrxPgXq5HAqTVAdUK6bnTA2Ns5ogEnJetPCgl6Li+P1jJBwVK/diNaVa9n4jQDLF0Jha1G7P/SnCZoFc2U6WGhQMXgIyTdr+nRkLpiH9IXzkJaWjkqaPNU0eeJT0zDtEx9B1mc+yXtzkbZgPtLZ8OH1DSjbsQut7e1ImzgBM7/zDaRedYkVn+lkkLiCOchk6rV2dWLipUsx5nvfRNai+UidNR3hWlPU606ByksukAuPS0T2xMkYsXABNccZCEtKpEB5j2YJumzHjgsOrEN/ewQHXn0TMSIPkueiO25DmLaeSCNVODtOkI9Dp50G7wXHxGL4tGnIYf1yqCGFa7Fb5ROBsh9ZpbT+etcEaQ5LE8wcOxaZesOCg6aY5n7h8jdQ/95G065yVXQV6zahevtOJMTHcQCNMmtVtbv3mTXq0fPnImrBXIRSOwhtbkXBK2+g/GXWJT4ekTSzq2gSnnA0wf7WBOWl2elrDmvv4phpU1F34CC2kkjTYuIw5sJFZm1X2rE2XCeFhqO5qgYV7O+akFsbG5EweQLmffYTiJw3h1pkhBlnCAtHQk4Oolwu1BQUoq25Gc2cLLuopWXkUmPmWAhytCyWizEcr/6iWWuVpaXoSUoAOMF4OHEFkzS0TzIoNRkhk8eja0Q2ImiWj2G+4ZoAtu1BEWUczAnVQ0uvlPUo3rWHZmYVPJ2dpl00cSTmj8OF3/kvjPjUHUi7aBHC4hNQRVlXHzmKEBYkYeZUDLuImpo0QbtsPpIzROc+dBRFy19H4+oN6GDbtJWUoafLxQlNbU8TlyZyAsuZlZuLrKxspLK/hLe0o40WRN223WjcvANNWg/cX4CwE5VIYF9IIMFHM3aIlnY4OUZTI0+lJtvF/lpNIm85WMDxlYIgraWyXH00QUeAZwy/vuGPQNd6wdwZwKE7rybWT6T+yupEM4f+MtRNtwdJHW5kVtShg6ZnV1YKQtihWrQ/rb/E+8HpEKAhTJM/SYBloFpGR+JVGpz5zcMcO3/RgHWdhKIsGM48xKBTEJOt4jKet64K451gOItqgCgPkbsi6UkeTUdDNJxQ+hA4J7QimRCvvQVU1RqtUPBtC8vLzsm/3Zx9m9kB42nK6iO2HRwwq1e+jaAtG9GhIgywd8q6I63FQRBczC9z3BhqQjchVFtfbJgy2n5B5TXnZpKkj+WoWLUOh9/fjAgOABfrpb1lkayq4obGRSMjbxiiLpiFSG1/iQyHm6TSQdPJxJcWWFSCY6veQ8fGbeiKj8U8bUFSW+i+I59TQuEsZ57uksjYymgnYZWSGNIqqxClCUXaGMk+ihNpaJcbYRz0cYmJGD1+vInXuXkbXMxb0pEYtYNA79u30Uw/uG0Xutg2O594DrUnynDRf30ZmDGZk47VVhKoZGqVm5bi3Nm48U804zUZlVViz+/uQ9Erb5rN3NNo5o7/+fcZl63JNnTt24813/sJKt+jJkdtL5QJSCHp5oSrp93Rw7ORRPWkTSTc1oqwjDSEL5gFDNd2E2ZWEWrkrrnUajOVgU7n5q8f2P/bOGlsePhxBO07jKigEGvrDeuiNARPkAcNDfU43twI9/69VkJ2YiLKME4UOmo5y01hySkRjZ1QbeVi4KaWZlRxMnJRaWsDx/zE8Uim9hpLTbKkrJT1NBIzaToHwi4478mktAaeuXQSdFnOqaSVnBPYFoR91wkTMCkjLBZZeXrPbTgR/WDGmH1Pfi950S+v43r/WmlaSUtw6mbWVesZss6se1YYSZRQoU6Cc80qswE93lm5H5i7nIlrX30ba//yEKK1wdjEZ8NRG24pOYE42iduaglb7/0Lop58nkqTTF0mT43DXVkDNHUgNjgUDZw51372y+ihBqstI2r6Hs70Ls7YYa2cEXtCceS1VSjff5hNz0zYYdo5K2dNm4TpX/w0MG4kgoxpbIOzfNfR46h/azUijp0wxKl0HTghdUV+7fuLZpkMWSt5mh1NlbUcCDSVfJLtC8V20rQCmY3TvNQSGYpEaWaXX8IgvGD3AXMwUeSxTzg4tI3bRGRYbRj3kNxyZ0xH6vQp6Ka2FXS8FFvfXIlQBgtmHtL0E6kNBevNDBKTi1qCNmqDcm/Yscc8fEih1TAqf4LZl6nNuRpE3nxOAYWQc+uBREw0Eq+4FJN37UbVijdQvXc/at7fgtzgMNTu2YvdDz1Fy2cbB34wwiOj0Mmy7HzqBbiefYlp2PXUwTljHSNJROnUiBpJ3h5qnmVvvYNXa2tx0dfuRsxlF1F7pGVEYZlogvpiOE3SVE6i7Bfujja0UwZKWG/KdNKSQqpImU1fdBxv/+VvaH9nHSL06qvMZYZ0JyYg8+IFmHztlUiZNRWNr76D9//wgNk4beDt/H7wFqIvFLr3Ficokmy4Nrq7uhDMiSA0K5MWUqx5sKK9qG5q/0H2JK5+pT5ukRzbXOvI1BxdIuzwSISybV2p1ptcykfVV169RQxCFO/EjRqBYPP+NpA7bJjVf/0hFndzcDaWlaFEi7JHi80CeL8V7gfq3N44ysf0ZjtDXZdTh5GKzplKAjEhfLOx/b6XHHjDOUlaBy9UD4/S94cJaEWytCB1HOefNzkGc0jRgumO5mbfnHpIanWFhajfuQc4VsZB1WFmuYDyUn683ETz5yjjHC04gsKCAhyhKy0pIQ91mDLJnK+qrMDhgwdx9Egh7zMcw9ey86tOmpg6me/x40U4criAafD+kQIcO1qIhvo6Zm2FaWlq5L1D5p7jys1XtdmeTkUdsKO5Y6LgTk9GR3YaOrJS0cljr0s3JlRYZCTCSYDhbLduDuJ2mpoNuZlozMtAa04a2hlO8Z14HTk0wzJSEcxwYQwfzbYOUUcmUXRTm+hQHLquLIanpub2Mdd7zF9fOFcsOXqh+rLs+UsWIP+uz2Hy176MSTffgKDYaLMsY9qOplU0NTGZo26a0x11dWwnakjUqLTtppnnyZMnInvqVKMp613Uk/MfHLpV/uHDMPGypYjKTENTVTVOrHkfJ158Ga/+9R84SLPRw8GecvlFSL/larTkj0JTXhY6c7PgGpZJlwFXjuW66FopXw/N8fzP3In8L3wSIZzA9OpbNYmtrk1kznr4tydhhqDYgE5akjMkNSrUdoYp6PSopJV17qTZHMyJwEWzX29pxOdkYdGdtyPlmivRk5aCdkNGnBoC5GXA66q6RpIlvZMl6HtFyZh9qfQljh6JZV+9C1fc91tc8+d7cPX/fhNT58/DkoULcd3dX8SNv/sFbvjz73HDA7/HdQ/w/ve/hcz8sWj3uBHLfnnRf9xp3X/wD7iR969/4A8M9wdcz/Przfk9+Aj9l37/fxA9dgwzt7TnPuawx9ONdrJrRQUHH1VjbT6s4QyWHx2HJexQyfpsjZ6u+KBPNelxZGORC1VVHgxrU6BSXfUaVohU824q5F10nIX1I0sNBcfQQLKV+m3F7Qv/KyeHUJ78wzKoPDIJO0gSR48eRVh4GGJjYxEdRfODjRsu85H31QlcjNTNvmBpPE5NmJC8JhPrmvXXztU+qDPVk3AObN6Mg++tReueQ5iZmI6xV16KjHkzrT2AHHDGFLXjmIRYhpzJk3DVZz+FKJfbrJ8YzYnmSsGq1ag/UYHo2HhMWjIfeprYSnNJGmYPibF2606UUqPQdxATsrMw55rLEcKB7WJH0GK0BneN9pvRbNIXs3PzJ2LsVcvQosmA+Wgjc/zwXPO+pbdMDkgiEy5aYj4SEabFaQOfykrAR0uw7bFnULR1u1lfctN0nPuRmzH8pqtYCVXOge132pITQ8XKd7H1heVw0ZwCzc2Fd9yGTGkwWjNiXDfLFqqX2rWRm/BNzTrre8X0E5/RaF6v0ogKpYcmsTqfBqxOzYCkRhGeRIMuPoGyLDWvnqG41KwZVm7bgdj4eKTOpXmXR/OOmsnJOwYGhkI7MbqZXwg10+x5s8zXWnaxXTuPHEfc6NGYRLP3CDX1hZdeimEfv4V9JAIzadIbQj6pUWzosh40kFDTSFaZI3Kx9sUVJv3cpZQhNTxJxz+2twqqPv94T72i5BXKKYJa2NSrr0TuNdcZpWflPx+Fq7YT3aEhaGY9EtlG3dIOGVyyVHTzkQ3Ft06Msx5OWZetGxbMKdF7xYKviLWNri03wzxE0oSFomKsf+89BFfVI+3YEcz+yueRNHGcNZ7Un13UBKMjzSb+bi0HpLFP6xU+TaL9wRASI/jAG1qEcfjwIWzdsgWHDh1GB8kphR0svLYeJ95agxc3bcWir9yF8TdfD1BFPhWcOVSvVkljSOhyI7GhBXGHi4DSGtQwj3K6qsLjqDxyFO00/2IYRaagMb/9pXUKSKU1jWMLVWTX1taG5SuWI+yNcKSlpiEzIwOZVLdH5uYhi/2tPrQHzbEUYkSoeZNCr6h5s/VpnN5xZt81F4JQVVWJF154Acdo8sS3diCG5ldJwQYUvPw60ifnY/IN12D4dSSHMb5bPphGOIl49lRMmDGFpzw3yTJNat2lBQdRVl6BOMo478pLkHjrDUgya3MM1NSM8H88gdJdu9hercik5jCMWoFZk1GRlE5dA8IffARF+w6gxdWJ5BmTkfy1u5CsdR/dVzh1BLOOqBMfsPMEZaUjjFqb6WQmsB1G5/WNZkOvFui1H6uN5tewyy/GcJVB2zW8ycljKmUdtWH0wBG0Ufttt9fhotmZMz96s9kGYgiLEFmZuLaJblJxyNcLpWul7TuQRYgRze2o37AdiR6ac7ExaOPEGt3UavqGpeMTqalImjQRZQcOmU2+rS+/hRN7aAqThDIvWYIcOujpa1m5CW5+pkHt3dsJBgcFV7XSU5EyfhyCqGm2lJ5ALSerWV/5ImZJC6HJrbcmTH3MwzunQoos53NuLvFcsqCLveoyXHkJyU99g9quHWoAsG/3hDiS43/5lB4PJLgIapYTRo+gxdeOtqeXk/w0gfSWIBCMbDTxcXybNm6nUsNxoFcl9UJAn8mfMOuEfdrSumauOzmpXFTGUNeCY+s3ouf4CYSRm2LLqxGxfR9V3wY7TY5XmsJBJMgoBg9ubUMHlbaY+Bib5JiOkvTmZ6XfnZVBLXq09c64PSatv0QjO+i6teuwfft2o0FERkQwTDDNHg9SSUzh9U1oOUoCIzkGhGkg2y/wVGMtqqMLicdOIH7PEXS9vQ6vf/+nePiur2HFj36BnY88jdq1mxBdVo1sTjGJIkA7rknL1/UeAsIMFrsIvi4yItIMAv3K3M4dO/DWm2/i4UcfxQNPPo6DJJKe+dPROXEMOmgGdLDAxsSWI3zTsdK2b9ioo/lUXl5u0g+jlqEvlCSzDukdbvPEasVv70XBa29yitMytJOonaLWOSQgNbicZlXK2jLdaMbz3KVrCs6B45CS1qnsqrLv8ZrbZce106Fz0em+nL7kYyJQizT3VUGjJfGmP1Q2lUn3RZpy0tL0vTkOjuo167GGmlxLbS06o8KROX82Fnzm4xYBaiZ24nj9PKqjcTIq27wVB9mp9fAkMjMDEy5bZpE3JyCF61Eeykt5swimPU2RJAB/2Nfse9JWtAuhhXmt37QJf7/vT3jgl7/C0888g2ZKoYMkYfZPKs2UJGTNmIpwWgUtJeXY+OhTOLRmA6LS0zFy7mxEqEz24JAEAy6n9AOrxBZM8VW+qCgkjRqBOJKhh/2tiZZDCy2tE+vX4+CDf8Ohe/5Mdz8O/eF+HLSd5f8zDt5Lv5y5xnOF/f2fcOh3f8KBe/+MvY8+jtojR2xxBJKTH7yyFBnZMVhQ8+aQ6kz597A9OtkG5ks6fvBOJISqZ15Fq67BiddX4vhfH0UhZVm7/5DZixnMesem0RJSf7JxUlsqEeZvLrNfWroF86Wl2HG4EAfeXYNwverIznps1x7884c/xb2fuQt/kPvUF/DX7/0YxZzso0PD0MRyrPjbP3HP5+7GPSbM3bb7Is+/iN/z2r1f+D947r4H0FBSao8nCyfVNDQkjETKztgHMmupFfqpkSfDtxuo0pykWtqRvrsQOdsPYvj+40g/UoLUihpkkChSODPFckbUt8R85gI/UfdN0wteNjKz/V44UWynMW9IippPBDWXsJBQ82SwqqsTZbERODY+D1WTx6KZs38btUeHy71kaLtAeelzYNI41bjmHv/qeV4o6xTFY0JnNyJZf0NA/mA6rTTHDr/8GkpfeR2lL7+BirXvo6O20TyVc7e3o2zXXjSvfAcneK/81bdQ+vZ71KCphelhCkLQWdeISnaU6tdWmvjlr7yJkrffRc2RQgS53WZfVGNRCZreeBvF1E7lyjZvg4capW89Toa3tgzHgMyvbcsOs7et6+Bh1qwbUSS+Bf9xJ8LmzLAIz7eDGwbQkdfYoTv3HMCB194yi9jh4TQRZ07DaG1y1aztaH1OfB0kzz7p2UcDE8BKW+AEEJKRgjFXLMPCT34UF37yTlz+sY/imo9/DJf+xyewmOdz7rgVKWNGwUNNVoMykdpnYnqa+RqLTFSwjdJYppFz56BDbdXaYpJWvzFWyWngJLGSXEI5wYbERJnXznrq6lG3dSf23/8P7P3xr3DgR7/GoR/+Bod4PPyj3+Aw/QU//g2OyOmc7tCPfsUwdObI8x/+mvF+hd2/uQ+1bBez/jxwg1pi6yeMLVFC9+nsgzMWeqEbvTD77po5wb3yFnZ952c48OBDcFG71scx4rOzMHrGNA0S/0R6QSJyU0Ho1kTOMCGczLQlRu8g76fy0EgLUV+Gkak+fNRoTBk1FtNHjcHMEWMwi/6JtOgSomPMw8CIsHCMSM/kvbGYTacwM0fySDdrpOKMxvS8URiVmYVoPSzyKVQguvceThZC/7Ce8PUNLWrQJTPTiOHZIYJIQsYFIFRHxL2iNqWwvP7wv+wb1D+aOecfFUYDjHlLy1UnN+q8ZiNlaspphxd8/YQpl++5M9gFek0axmt1Sg3kPvshBScKO0D5th145bs/wsr/+T7d97Dqjw+i9liJ+Z5cBwfs7qdfwItf/1+89b8/wBv/8128zbCHXn+LGgU1daarN0ze/uU9eO2/v4uV3/oh3mQ67/zwFzj89mqz4VRkenzTViz/5vfw9rd+gLe//UNseugxdFRWWfUeDDiru/YcxAbG07u34R16mh2MRBK8a99B4M13gV0HLDOlUx+KdYTAowil6AQOP/kCKjduMxvXw2hyDb/pGuvLLz5awoDoN5jyoqypZeXedB2marmGbtxdn8eYO+/AmGuuwvgFF2DCqJHo3LoDu376a1StWo3E1GRMmDYFnRyfWiONGjkMo2+8GsEcgLt++yfs5WDGkSLEeMmFzmncU0H9iwd9WsyQU7vLfB8Sja28zgk4MhJBOZkInTMdwRctRPiyxQhethCepQsRtGwRsHguPDTZgkL1JZ4IBOflIOyiBejRPbqgSxbyyPOLFyJ00Vzr/XOjuQ5Slk5dGNz0TPUDrf/S3NRyh0mF983OCZ5YtdZf2ScWVEP904dftX46YskCdGQkoyomHE3pSXDPzEfmjVciSss9muQ09vxh+gdJkJaB3jCRBhhLqy2cZWl6bRWOL38TPZRZZ1I8hv/HR7DwoT9hyaP30z2IxY89iEX0L/7F95E0dQKaOClHZKRhzhc/jSUP/xmLHnsAix+3nfwMf+Hjf8GSx/6MOf/5RYRr+5VX2/cjQauqp4kA9fOHSdOHYALm4b1nJ+gUxnG9By+8twKk6XtuwhnCstL2D+sLE9by9vEHgldbOVWCvrCjCNExMUjLyEBGdrZxiSPzEDt5AmKmT0L0tIlIHjMSqTm6l4VMHTk4YuPjaElribsHoTTxFD8zJwfpDJOu47AcxI8fjejpExHLdOLzxyJFcenSszKRmJzMyZma24CF9gE7allRMSpoxrmSE9AcHYlGmk3Fx4/j6Xvuw/2f+zKe/tLXselnv0HF0y+iZ9tuQIO+qY0EWIa9Dz+J/S+9at4y0JPlsZcvQ+qFFwBx0X1kMVg4UTRIQyX/1g50FxxF/fr3UbnqXRQtf4V5Pop3fnsPnvru9/DgN/4bf/ifb+Hx3/8B+6lNd1CT7lR4fZlYkx81lazhecgcPZIk0ICGtRux9i//xMZ/PGo+R699m1ampy6sQsjpqzqNJ8rQ/OYqVD/zAva9+iZaSTKesAiEpaQgd+EFuPiH38NNv/8NrvrSXbjm+9/BDQ/8Edf+/QFc97tfYDjN8m5aR10s25RLl+HKv/4J1z94H67/5c9x7Y+/j+vu/T1uZtjb7v0dxiy7yCYaU4T+obp621x0HISIji6zVlv01AvY8Lv7ULJhMxVrJ0zv0XeyVxqOM9uuwkKRNn8Olnz1Liz62t247DvfwB2//yWm3vVZ62Os/ZaLN7T5Xe/+trYbxUiy3rdjJ1Y/9yJcnDwlx+HjxyFfr95l0rTWgw+9K50qR782ilN71ENNKTZhsczPG0ZHOh0VXj9NoY+I6HdctE3I10xnBU0NKysr8dxzz+Hw4cPGzNNL5vFdbkQdLMSwbfvhjo7ClE/egSlf+JR5etf8+AtY/p0fIaq2wXxUVWIJiH6FQJicGYD/rXmG84thSvnNTS9MMrwU8KOq1i1vGCs9HvSHcJJ0wlkB+8KEdeLpAj0mHqF7EpM2Hk+bPgNXXX2V+ajqoUOH8PTTT6O9vBJJbV2I3bIHo46Umamlg2Zac0w0ln79y8j56mesQe+bsRQFDrrmkhKESeFgB7BkQOdbPvtUCxTu9g6UP/cyDj3+LJobm5FBbWbBd7+B4NxMdDE/o4OYciud3mRUD6uV6UmIRWx2pnkHNeAM7Q8tcje3oLm4FI2FR9FGDalu3yE0HjgMT1UtXNQeZLpL+9X+rpThw5FCAk8bNQLt2qdHMziopg5uEujwSy/G7C99FiGzpSEMYCYFAitgviz91IvY8PPfobahEYuuuRpjb7wOa555DjUr30UITSu9NqjtRSK3EPbZUA7EMA6WiLQ0xOcOQ0pUFEr27kPlzr2IdrFubNPQMSMwmaZ0Umcn1v3zYdRQG5k5bz41kUa8v2G9qdNCfVT1zpv6/ahqF+Whj6q2rngLkbOmYdrll6Bw/Xoc27wNMcyni6Qmk3ziVz6LrJuuNpNE0YrXcODZF83HJkbfcA3SlyyEq6MNW3/wK5Qtf8O8HTXvU3di7A++CfeefSh6bjlONDZgBokxbtmF1mAPpE2rrf0vU9tqP3ocO352D+qef50KuwepzDc2IxX7jxxBVGwcFn33v5By+3VooOa+8ke/RFdlLVJo0s7/6XeQtGg+ujvbUPnwM9jxuz+jRp/XpwaobyBqK5AFZsr+gvp6tLOcoXFxlH2CefotfuhTJHVIpl/wmz9hPSecZHbSkddegciFs1D+8tuo37QToax/HEkrZdxo86BG6+RWxYLMeNByRg2tlKbqWkRRoUjh5B+hD+yy/4sYe4XgQTvLkDlrBkbpQaW+iMP8HSXG+9pca2sr9u/fj9raWjPYlUkEKxRWU4+4Cs5i1Do06DJmzzDf5rdem1tjtlIE/IBCP7Cq4AueWf99rluD2MDc6BWhOoZHr83Zn9LyVWW98W2P77lVX6ZrjlZq3vuEfdnAe91E8mk8nuu1uXHjxprd/pLV/n374G5uRRRNvYiyKiTVNZsENEtqMX7EgrmInz8T5jWy3pQMRERRJNNwOWpoETxGpPCYnEpHvxzPw3kMk58DGIeOoGzrTrOVKY1m3qiP3obQEcMRkap0rLARdlomXaWp9Hg/Io1H7ZNTWfwHcn+QIhQeYX4kK4GDOHXqZOSyD4xZPB/pNOn0InuPXj/ijNzV0ob2ExUoLziC4h27UbGX5jJlozXftEkTcMHHbkew1hCjbQIeZBEscKK1X5srXreB9e9E7oQJSJk7C0c4cZcfLgCSEhBJ7TmeJJwyfzbyLl+KSTSTp9x8HUZOmYLQqjocWLMeFQcPoTslCSMXXWAGaSFJQB+xqN6zH22VVQjjJD/l4gvR3dKCQqZtvTY3d4BPaVmvzem9bxfTCc7NxuSlFyKE7bW94JD5CIV+fGrMjdcgj9fR1YljTz6PTf98DLUkzwrmEzx2JPKmTDIb48veXW9+rkBbP7JpUqYunofD+hjsU8+ZfbvNeurNvhOfm2u2YJl9gD6D2guRBieq9s070EVX8c46VK7bAg9JQ29ZtDY3o6KsDK0MF8Z2HLFsCWLGj0LH7oPmAwrd1NCiaH3oU1pRJDppzs2sZ21rM7oz05EwfQryFtM8lwamMjB//Q5M0WsrzW/kVLGs2vGhD2Lo91X6NLiGeHUdSl55g/1kHyLDI5F+wRyMv/V65OTnIzg7HekTxmJPwWHsp3ZYfKQQxUeP8ngMJYXHUFxYiMqiEgTptV1qgW72jRPVVSg4dhRFnKyLjyoMHcMX8/wYNf/QeJrWM2cgJC2lj6wGIMEeLwnGl9dQlQ9Egv29O9w/nJCDjmEHtA5Bfd4d9v+eoOP3anA6egOok/SmY45qCPu+Ofj6BVtQ+qugOs/yIcE6ymofG9DdYpFgeFk1EmubjIAdEhzZHwmaRHvgOlqEnctfRs37m7371apJctX6CML2HajiUe9j1uqdzJ0klk3b0HzkuPXUUgOy241aDuoKxXPiMKzimXPjdqBs92501tQgnkQZpE47KJhaS3JUVFlgraNEhhszRN8oFOFkcHYdOXcuRsbEoZ7aYg/7i34AKaS9C0Fua8O24rqolbVFhSOKZBkZT+3ALE47YNo+ojkJVjF63x1et9GQoN4dTr/sYmSOGo7c0aMx5ZorMfX2WzD6luuRe+UlSCXJReqDoyShI7t24f1Hn0JVcQllkIIZn7gdk7/6JRo1vLf/ADo5WDqpmfdQg8ymRjbmkotQwQmuWN8TtL8iMyAJsi8UrxYJWt8THE8TLoHEmTlxAmawXJNuuQHJC+eZdbedjz2NvY89gx6afPo4wKTLl2EOyxOck2V+x6PCJkG9NZEjErz8Ylp0yUjocKH+QAFchUUc6IWIY1kS8yeYSc1sV7GLJYvCeGna1m3dQa3uF9hD0q3esAVdJB6zDEjFopUugmQ2bukSTL/1BqSzr/ZQc24XCa7ZgO42kiDvD1u2mCSYi2DmE0/tcczC+SzzJcjT79Rom4/6hTJkf/Y0NqHu1ZUoe+l1VOzaZx505F602DJBHbmpPdk3XIcLcfiFFWgpLUN0UhIyL1qIOBJ+6OiRSJ09Hcm0JvSWz1i28/gZ0zGGbux0HunGT5+GYdTQ9Z3FJmqeMQkJGMM2mrjsYoydaYUZO03hp9E/DXl0o+bMorzGn7TXeQASDCIJ0uQ3JKj1jNMgQZ4apvW7fEYwaYi0rMS8JJjT+wGFPug3T91wnE8wx2MayHu1j9fxq05ZWVmmUfQBhRqR4L795vWrSJetCdZTE2SfcEhw1ACaoB46tK/dhBU/+BnqXnkbVavWcgCsMzN2+TtrqRHo2Osq3tuAtsLj5ttpEez07qZmFG3YhJJ3GVb3FW4Vj3a8ilXrrbjvrjHfzdNPPErbCNZHXG14S6SO6Vc86wIlr4O0ChKu+X1hmsfmG3UcjI2r1ping8Ukcb12poGjZ+HdYaFwx0UbC0Kb4jtpEldt323WnZp4jKSGGK0fq4rgfWkJnM1trgtcDN51SFCf0uogCWaMH4dMDtCwyeMRR600Qj+cow/I6svZ0TRblTdJV4M0monXlZSiJSUeS774GYz46K0kxzQEjR6ODGpuej+12tONZGoh0++8DVFjR6Fo9Vqzl1XldL4n2B8Juqkh6SOf5lNawzJpKi5EyKypSCSJhY8ZznqyPHsPYPsDD+HoM8vhoVaqhyQZVy3D4i9/HsFTJrCcIWZQV5JMW6UJhrC/zZiKNO0HZJ9P0E+Y0mSvLTiKjvIKVFP71faQRFoE5vd/7XKZsSdhkpRQXIZimtYuauh60uqKCIcrNdF81Hbinbdg2uc/gTEfuw0xC+YAyWwPaqKSsfUprXbzVZ88kmRkHrVOkZ02bGuPnSZCrfk5BCiI2MoqUfjSa2glWXso+5Hz5yKNJN53AzMLUt+Eo6+/hSMMG6Q9xOPHYPx1VyB80nhqjWw3tV1yEtKp0adRE02+ZAlS6JKXXUi3BElLFyF17GgqBrtQXlKEBE5mMz/3H0j/8ueQfOlFVljbyZ/J8HGT8+11ShWYzi53PyQYbJOgowkOkgRN2pqF2KHVCH5wiOwkmHi26wfOLV9NMBAJDpBEn3tev+3xL5t/WFXHnwQlq7379lqaIEkwnB3A3xweSW0gXm+PaLD75aEpubuhgRplHZKzs5DAzqzvuTku3sfpU+r6SovednHTjNHvIut3RdJmTUd8/jjEai+awthOcbznvBdDUzZz+mRqbjRh9TuxNrwlcjxqOJq1+kKMeV2ysBieI0Vw7T+M+o3bUPrWu5y9X8H+Z1/E7udewqE338Fxapq1+n6hfviHBBQ6YTSGUxNb+NlPIE9PDuOj0UISdbGv6GFDA82UozJxNm2Fh4PT7A8NC0cQTbwga8c04ScrwiLBQyhdu9H8GE8yNcpUElRQVQ3cx0rQfawY3Syzh9q1h+XuVtk5acgfUV2P3LBIjM4bbr7WA8pcn4IHyx3b1Y0xyWkYmzcC+WPHI5omsoumVtn6TagvKTMfPcjjZBZNrVIfhD2paMYcrjNfkXEZEszC6AsXIpQaqvZB6k2fqq3b8c79f0PhytUIb2hGFwln1JXLcOFXvgBocAokkbDaelRyAmymlqSfKNB2ojSt/3GiCOIATs/MRAfrXkMZ6qcqC8vLEUdtLGXCGD+iEWiRkFTLj1MGSQnInDcL+TTJZ3/iDky87Uakk9yiSD7my9SaiFgvybh972FqguvNhKeljASakYkdXXBJvpz4JGPj5Kd8uwvo2Eegj/Gy7MXvrIG7rgHupDiMZdkTqKEZsnTAyd98gu2JZ9C056B5jzdlzgyMmTqV5F6JNnJLN+vvLiiEi6a/i1q6i9aPi3V2MT83z0F/6979KGOfbKmsNl+KiUlORijL76Ip7I2jI8N2KZ3DR83PT3SqT2ingiZh8smgHozkbLcejEyl8Po+GPkxomoazGdrTCIkQHMwJKieonPnms6ta87CvX3LEr7jdTx+UEwFOu0HI/R7l1N979HJ4zWdT3HPiImdcsaMGbjqqv4fjIwsOAF9lODkByMBTFClSc1Jn3XX3qqB6q4VlU5OVCcefx77/v4omhknmxPSRT/nHEZNxt1fZBt6G0ZfNTG/L6LZvD+wTJ4DR7CJpmP95h2IamqjdtdhaXgd7ejRT1F2uczA1gMILUB7mF5cZob5xlsGO3PS3BmI4qDUD0lpg7Ze9m/bX4DqdZtJYO+jbjf7EyeOUPYzDYDQkblIWTQPuVdcjKQFsxAZSy3DV9syVXN+cnM5Nv78d2grr0KMNsLrw63Szvyqr9i2Uci/MhBZTp4aLUmBFV4HXdM/yse6zFi8qH2WHk5QLe00Cc1Pbn4JqR/TgxGZdSbZXnCcaC1w7Y9+iZblbyJo3gxc9u1vIGLpQmv5wOVC9859OPTIU9j3+ipEMHzezddg+qfvND8C1VFRgfJNO8yE6KKsSplGK8leH5SYw4lk/I//15CpKbP2bO47iB2/uQ8HV76DUYsXYd5nPo7opTRNtWbsyE1hdWhoQsvxYoSQILVWHCzCi+ZkI/P5pIoQbNvW5Svxxo9+ji4SXazaiP04jJO+lgrsZG3ozFYf1JdFQG2tpr+0eTyInDUFN/7ku8BCkqBZE7TDtXeg9vlX8MbPfsOJtsSsN07+9MeRExuHjc88jwb7Vw4tsPVsbxD7uLMNT35trelp70K3Pr1FkjW/CW0e+NkROLmaMnrP9RYM2YAWSu6dH8HMuzkBJUYNpAkyvdPWBP2fEjsVsaA76mRWoXzC0asz35j+cO4F0gSde974tsccvBctr5W/aNo3UN+w9iHA+cmaoGRmHozIHD4hc5imIiP00QRlDp+kCaocPFCuobExCKGJoQGtjwwEcoijhsXB3kKTqnzzVpqDHUjg4Bxx2w3m6VwwtUIrLNPxiyunbxfqAwPGPHQGig3nSZk6myEEms0H3luLorffQxAJ3l3fCBf7h75M3cyO3khtrTGOaY0dgeE3XIWpn/4Ypnz6DgxjWeIXz0c4NdYgrbtw0Cg/aTDhuTlImjMTw0l20WOHo7KlGdXVNQju6EQLB3/ZiROIyctBOjWfUHZkjQGLsHzATt/B+pet34Culha4ONCqSLLVrk7UdbXTddD5+h3nc6+Tftajnn45bxhes1w7Gnjewnuh1Gw9PdTwqRkOWzDbXhN05McCGtAvc5h10YORLpqxMslHUwMOpRwcUz84NZWTxBSk0TzOo7k26rbrrKeqHLyu46XY/dAT2PGY3qDaaL7Goy8GtcXHGE06hVqo1+ykZqZfEswcNxpp1OxmfPwjCOPkY94dNsqWTUr6Q6efN4hIT0UY8w9mO3jXD61QJ4NlDaeZXt/chIL9+6xPjpFkminv5hYSKo+trfTzfgvbUOfNPMq1kADbSPCNrLI7K51K0+3IuPYKq+87bakj+0V0YqL5SdhjBUcQTY152h03o4Py37Z2Pcqqq9HMybaB8jeuq9dfT3+9c43WUBPboYWc0MRJrIFtZe6xP/TGUzt3eM/VB5pZvoQpE83Y1CR1jjVBq2uY6tp9RLOvm05No30/+iSQ7ttN5Y1nfI7qFQBOkDPdImPdU2CrrE45TL+xw+m3TI22YJ32gvcDaYKS1ZNPPkkVvgrJbZ3UBPdiZOGpt8hYpGO8hMin73lAMIy7sRlHOFi23PcXNNY3IG/eHFx376+tH5RRtH6i9gcr3wCRmttRveo9vPnz35ofxY+IiTV7sGLTUjFswnjkTspH3PBc60eeZFprjUivvbFT+1TEB2bqYfF4j4RhXiMsrkA1zaZNz72IiopyTFlCjeZLn6dpODZwGkxAmmDFitex/r4H0MzJeeK06bjg5hvNZmnz+qCB4toN6hWI73l/9wRdY/mCaMJyglv3zLPYt30HEocPx4LP/QeG3XQVgvVAx5TPJx4nwNbDR/DuL+9B7evvIIxEd9V/fxWJ+ogqJ2oDBTfrqnRieNv8NH9OVOPAXx7CempBkVqK4GTXTVLLWjAHl/3XV6yfDOVAtxJheB2ohRsPSdGUx6TlDXHa8PYFJcD66K2Npve3oIImp4tmsT7OoQEl9cGEN4OLjgPGxLOj6rNXsRlpyJkyCZhBJ8vD9AsTzYICSg4y/dnPGjs7MYoTg35r200z2Gz0N4mZ0D7QBd2wb9lh+gZ1fFafE+wRb/zaZuOR7EfkInwM5SpFipU3Yc8VCRo4uRPdzLCbGoheqg5m5YJoiwcbVZfOCE9OISkUQ4JOIn1hrjKKPwmqLZwYThh5zEF/CIsEdULB8GAHMdquPt/lofC1r8yjxXwSne7pry0aA+P3I0GZw0899dRpk+Cg4BTSAfPXV33r39+G0tXrzQcvkkYOxzh90ELfhDuNpB14O74/2D4yy46t2WBejUrSV2do2sqUDqXJpR9csgYl4w6UryO+QGF0j/2r83gRio4eRVpuLpLGjYF5Ba8fyAR3lZajltpWF0kvITPTLKibhyD+UJ69zWfBX6b9QeGoadcfOIT6snJExsQjefRIRORmsp9YJNALBma59ANJpeu3mHUoj341b95s8+NURvN2YMrDP47M1afkpzbceqgQFYcOI1QfIYiKQDSJJJHanj5cqj2kVmeWU1z1Zsvfb3WcoDZ06kCXnfM+8X0vys96mbc5jFquHEWCvGkGVN8UrHs641/VWc6IyroaEKq/lh3EDWH25KKJImBwJx3lS9c3exvOfefoCycg0xcM71hteW5JUDB58YyZuFm5tuQEtE8bDzdntm5qAGkh4Zxl69HOzqXffg3vdCGM4fQ5KWdG8RIb/1iNbV2T8L0kOGsiTiT1JcE+9dZFnpums6pozHx14vjYWAyLjIbraDFcu/ajieTi0kcAqMI3chCa9HzTIgxhiATtzdLJPmuCWsxNbO1E3LkkwUBQPSgv4wS2E6LYefxn2kHAK9dAEXVLW3A0AOQ3HZrh5BR+gLwUfIDbfaHAWiRXvUz6rIfJYwDoVTSjBREKL1I6VRwvlKFghR+wrBr4ysdM2AzFfHq0iG7d9QHvK4iRF8NLZmoXaRte0/kUUB6Sg7QjyUJxVC9NNGZMOGnYZTlDnFFsRXKgwWYUFRvm3PHTOff8MvEN4qB3Atbd3jt9z84X+uZCKZ8fqJLKqp2kUpkSj7LcdLgvmIHF3/5P3PKPP+GO3/6MpPoRRM6cgo6cDDRSW2xjoxuB2eVzBqoXvO53xYIu+t/guRM/IiICyckpyJ84EVdfcy2+8LnP49M3fwRjQ6MQu68AaWVViGlrJxn3fsvQIeQ+8ElTcMLqiuM/r1AeWmhPiLFcLDUgDZZznbXSU7rKSySrAW3y4Y0B8uqVzCChtJS2tD+HaE8FEYPWmLxbawYRx+A0S6d09bTV5KXyWUPl5FQYTnIR8Ulemuy0GVxxB9snlJdkIFkrro46N5ObbxqDTK8fnFFsRXKc/vR33sdvYwCR946XvhbXBwPfQlLM9vHcwdRH+gUzol8LvFp/c/GkhbnVxbCRR+ci9IbLMflXP8Q1Lz+Jax+5H3O//TUkzZ4m6XBitKnGzCyWk7Kta7rkexSM3+dcUbo93Yik6TZv3jzcccdH8aUvfwmf/vSncfGFFyIjM4udOgyRjBBKzSLEaMiMpLzpUzp66unNx3ZWUXq1Xt/G84b9wBv01DBls7xeONVxECjM4CFZWSn4pumPwebRG87yDTbewHBq3FvCgcoaCH1jnwECVsK3do4/YMDB4Syi9guTZn9lG0Aq9uVTyc0Qop3sQOHOF849CQpeOZEKDeNb1KKv3OlXrrqNqm9rAPExiJ49HWNvvg55M6chhNcMkRjJnSx0c6kfKCuTHeGmVhcTE4M5c+di2vRp1ASTjTnshcwXZWNnpRMz3OwM7GQMHP8AWXsD9c5wCj1gjA8QgyuLb51PD1bMgKa1HwaTR6AwZ162fyGcshJOgLOo7fkQlEnzzMs2qFFwPso9SJw9CQ628AwX0GSUKUBTQ09s2umXNmUUM0dytmalmA5hOc6B41dQK7h1xZjkdvyT4E2gb2pevcM3Gv0Dka8vrPwc96+MvvXu9Z0ZzhUBOrDC6u9gUibOm7iVsGMfnA9YdezFoGobEOe/151d2bw400Kep8qdMQka08/2nxp9A5/KZHS40mxaVREHmVEvx/ZG6JcIeUmpm82X9CuE91zoh/X6K7shaDlTCF/XC8V0Yvv6T43TC+3AiWXq5VeW8wsr58GUujfMYEIPgIDVO8s0/XBGqfUT6YzSOgVO7nFni1OXcjB16FMujR/7xO12o6uryxz7jisnX8cNFqcTpzfcaZDgYBL2g1+rOCkE1AgDwBpGFgaTu5Ejk/bNx3H9oU8e/RCc4Uk7if7SUkwrjDd3+9gXga+eX6he2lLT3NSMjvZ26+MLA0CdUpvnm5ub4dLPIf6LQeVXfZqarM27+jmI/tru7KEW6221gdpPZZC8VKbq6moUHS9CwZEjOHrsGMrKytHQ0GDKfTqf7D+f0Bs/KqucyOhMcVqSt8eP5KCf8nj22WexadMmU4ZTYtCDZ9ABDfqQYP9RzRC3vDYc03QgCeiWHnI4gU+vaELvQ4j+4uq+E0aBvP5BwSqXnNGVvARnzmw/Qw0iXYckrZCBQ/em6M12kDi90A6cWCKJjRs34vHHHsXadesMufUHDVD9bsrLL79stv8UFBScAcFYOQ+m1L1hBhPagn4PZ82aNXjooYfMZvVt27aZQXUyBp/mwLDS6S8lyUcyLi0txTrKVz++9cQTT+DJp56kDJ/CUzw+8cTjZk+p7tfX1yvSOSnZ2UC/Kqk2FhGpnU9G//JTPxGJnmk9RLrKc/Xq1eatq3ZOzr1w8u0//8A4nfC9YU/SBM3lk/p8oMTtwe5/2QfilN5f6wqQ7NnAznow7tSQPqgCWg0qp3HvEL33ZwQDgjfp9ATcgpMC4/Uf6QOFOqs6/IEDB83rab6zfiCCkxaonyrVnlEN2DPVss403kCQllpSUmKIT7/DvG/fPuzdu9dohWeCc1FG5f3+++/jSRLf66+9Zr5PqHImJSUhOzsb6enpZpuWyFuvWipPZ8KV/3zIaTDQrzGKiOQMMQ8CIj+FFXFJkxtoQj0VzOu5ISF9H1h+CPDm7msWBh7xZzCimaQVS3/7n0nPBiZNFd3fnQ78wptTq8i9sMP06bA+943u6I3owNcv+GX0AcKUz784RCDzXtcc59tBBxqsge4FSvtsIY1LJCjTUu9wp6am0tQsM9dEPKdLKP5lPN34IsBVq1bhlVdfQQNJbvKUKbjp5pvxhS98wThty/rsZz/r9V900UVI0NdLbDhy7g+nW57BwjfdwbSTE14a2+bNm/H3v/8db7zxxqBJ8HzV41zA7uGWJmRMukF3XBPY8vYDc/d8VZ6Je1OW37c49j3HnRIMb6Ky7k54HbVy430u6KTtC+cGM7eqqaOTAuP2qbv8jvuwoEoMPOgGwkDxTjdNyUmkJS11sANEWog0qeLiYvMBi0mTJmHEiBGGiIqKioxmc7rlcMw6pwyKP9jyiBDWr1+PjZs2IS4+HhcvW4rrbrgeU6dNNT/27wv9yl5aWhoyMjIQpu/l9YNA5TkfON10nfAql8qoyVHa7WC1OMXzb+vByvl8w64BB4YGCMukgp2ycEbl8XeBwOtGdjr2F+bscE5SZSKqsm+9VWxfFwhWv2AcHp0+ZeRImLRMek6auu4466pz54PFINq3HzjrXjKfqqqqAqajtTlpZTKlRVi+EOnpmu7JlJIJKbdr1y4TR+kPBMWXWS+nfZ+jRo3C6NGjzWBUuWpqaswA9YcGn14LPUIzVWGUjkw6mdJalFcZ9uzZY8Lo3mAIQnU/dvyYiat2njljJi6YNx+J8QnePjBY6GGK8lZ5pGUpzS1btuDgwYPmt63PtL3OJSRXad+agFQmQcsqmnzUHyRbta2v/OVXWKdeWpdWW0tzH6ycPwjY76kRPErYjsB9y6crxnmv8cxLhP3D3GV60q9Ot2MMFibVQMUwxRu4fF6wsvqatm+jqLw6c9J31gd9wxhZOQEMrLrqTB9i0M856sOYvcLsjfvBQ6Vyyjl4+A5ADYK3337bPIzYunWrIRdfKKwGghNm9+7d9h2LwDRQnn/+eTz88MPmwcGLL75ozh977DHz0ECE1J95pbT1BFGDUIMvLy/PfNZMa24iRBGjiDTQU05dE+k+88wzJg8NSj28eOSRR0y+ejDglEdrXYHS8Ic+LbWPYSWTbJZjYn6+pf2dpoi1/iqC0AOKRx991JRHMlF5VD75teb5YT+lV/4HDhwwctuxY4dpD9V9+fLl+Oc//2naUNcd2emocjv1Un+QnBVO10TyCqM1wQ8b3jfCIyMjMWzYMO+bFd16mVsvdpv//BMagp7wCOsdSX24zDCij7PT8YVFJFI2edPYlTz2Mulpo09MFsn3vA8n2/dEWIPKjQ3qMXUViVlxe/Q1C980Hfic66crQ83PVzomFNPp6UanNn0nJSBx5lTETBwH6yOmfUvi5OOFfz7nGKZ0/CPikramwRfIyaSURuaQn0P6OldchRFR9UcUmv0VRiaq8nHS0XXFiYuLw6JFi/Cxj30Mn/nMZ/DJT34Sc+fONRrDu+++awgqUNqKr20nx44dM31V5KfvKyYmJhpCVNlEgiJKJ09faBBr0Gpgai1L/ksvvRR33HEHLrnkEsTTnJXmpTIcP378JIL3hx5yHDlcAP2GSk7OMORy7Bj0beYBIRm988475km8NMHp06cbuWjt8KabbjJ1lIb60ksvmUmnP5l/EBBZ5ebmYsGCBRg5cqTpF3ojS6+lSn5Lliwx1xVO5ZTGJwKXTFWP66+/3tTtmmuuMZPFhg0bjEWgpQFfxeLDgNeg12KtOsXtt9+OxYsXI5cdKywqEi1hIWgbzka+4hLkXrwY0E/oGdjD2O5vgehGfdHbHXnbhDjHZrFJzS5KX8c/g83KiWP9sdOk37luXSbk6U1U6zsLFy7C8BEjEBQRiubYKLSPG4XUG67Eou99E7f8+idIv1S/CzuI2c6bx/mBBqvIQeaLZm/Nzv25lStXGnPRd5b27ain6rSaRP3DqLOPHz8e1157rRk0+iSZ1vQ08HU+bdo0Q67SxEQw/hAxy4wSceTk5JgBqTw0oGQSa41QJKjtPYEITGGljape0iBvu+02XHzxxZg/f77J/7LLLkNmZqbJQxrrqUxz3deEIRnFx8chjCb56UDxRXAyESWbpUuXmk+0zZo1C1OmTDFj8JZbbjEkozIrnJ7YByL4DwKqp5QkTVgOCUrms2fPNnLUAx+HBLU0oS1Maiu1r+px4YUXmrCq13XXXWfa35lsP6w6OfCSoColZp8wYQKuuOIKfOT2j2DZlVdg6uVk+W9+HRf+7zeQvGie/UmowUNapKpoKYFnV9k+sZUeD/07amXm72Bg6az9pakbpvw8Mee22qkBuHDhQtx42y1YdOklmPvRW7HsJ9/Fov/7XWR/7k5gaj4QExlQ+e1N+4OFOpy0IjnN2L7OuS4SOdcdU/1La3eSmQa9k76O6nciIGl2GvD+BKQwGlDSAuUXAWrSVpoiXMUVsYlERWKqiz8UVnFl6YhYRKQOyUuzHD58uNEopXFq3TDwvsNeKJypAfMPttM5HYmJ6EWCOo4ZM8aQhbRRlVPQUfVSWXWUpqgtQYPaVHwe4FsuR5Y6SoY6OhOfJgZ9Yk7LE1ISLrjgAqMJOrLWUQ+IRPZ6qBWorT5oeEnQF+oUGewksy6+EDfc9QWMvela8w1BNbiBIQv+oyCMsWta3xKKP4zA5Bj23A4rC8rRN9c+/gDlCQhTNqs+gpNmb3xe1y2HxM3B6gwauBnDR+ACqvsXfeEzSLhqKZBHWfG6U5iAcrHdBwVVTeueGuy33norPv7xj/frpJXIzDyVSXgmUJp6qKKnqlr/0laLv/71r8Y8cojYn4R1rrVGxZP2obLJ5JZ57CzSa2CJmESUuuYbXzB9lf1XRCMCld+B2kfpKg09xXWWBvzT8If5OVEFYbjTaU/VR2VU+R0CVrkCQeSu+yJlEXwgLfnDgr98JEc9MT9x4oSpo8ougveHZK820IR0Khl/EAhIgl5oIEdRzdcnwvUrYE4r89idlGC+oKvf+WgLoanByqhC/h3BVJL/rd81OL8weSsvuxSDFrA6s/75kpWKbdfJrBfyggZINLWWkBBpMlYwAz380Hfn9IVjfQvufHzj75wgyGhhGngiEm3m9XW6ps6pdTtn5g5E4GcCZ03vzTffNMSno/NEUeSn/Hzz9M1XmqFDbnKvvPIK/vjHP+K+++7Dvffea0hUa2YKJ41JZKlB6A+l2F99NDDD9XVjQuWR6TwQItgXwkLDzG9wSAMVeQ8WKps0OhGG2kIyd+ruD/U5tYfKrTwkx38VqEz+Y0xlFGHrniYWKQn9wWkLHR3/h4H+mWkg/mCBk+bPxGXf/Qam3n4zYseNQgjJ0uyLo3Oqo3qJXIKNLWklOVCy5w5WLoMXbD8lsxs4JjYGY8eNM2tH8+dfgBjTKc2tc4cPRjCm0w56ciB8w55pZ1UaMjH1ipQ0QA38yy+/3DwYufvuu81GYmmfGuz+ZdO5TGStZYoApBVpLTE/P9/rJk6caI7S5GSOae1Mxz5pya9Tv/T9oQExmDrKrM8ZlmOWXEqp+WgdbLBw0neO/nUWnGs6OoR+pvI/X1DZ/MvjW8ZA9fKFE1/HU4U9n+ifBAeStSqZkoysKy/DjO99A8vu+RmGf+3zcM+fjvqkOLRQM3S0JylJshn0z+mEWq0LCMu2sPyBEPD+KeL0B9ZBXUs/rGQeXJOo1Q5qDI+H5hivSuubPHmyebKlhXQt7g7LyUaoNL1zjYHkfS7A9M9ASgZOp5a2JI1FZCRtyb/j6lyagP+angaxTCRtsZBmo3XUOXPmGHNJxKdrSjdQesrLeeChNSaR5Y033tjH3XDDDeap49SpU00cEaav2Wilq2WZ/mVg6ngaMpLWLPJV2VU2PdCRCT0YSDuS9iciVRxpr5KnLxyZi8w1gTimvCaQcwUnjzOB4gaKr7pJJmo3acgqfyCoT6iv+Le5Lwa6d65QwsnrzEeziECfHc9JR8jiuZj0za/ghgfuwYVf/xKiZ01BY2KM+WnGdhKXfn5SjRgXG4eoqCgS45lm21coaoJ+m1FBKcSA93UxOgqR2ZnoSopHc1iw+UU8/RKVbsZyYE6bPt1s3/jUpz5lnmrp9SyZkk70f0uw4GfSrZzOqPqrg8tUlFnqb3LqugaszF7BGSgKpwEhctRDEJnevmaSBoy2rIgQ/AeW4mjLisxHvYOrdtADFn8nQtEDE6UtE1vms9IVTJqDbLTBykekrafd0ko10LXvTa7vhwBOhmSp8qicqotMR5G26h8Iqoe2ksi01IMExRMkUxGnU0dBaeuaZC0ZnOrhzpmSjG8b+aYhv9pXD5jUV0qKi83k4A+VXROb2lX9wL/NVadTEeS5grY2eX93+KwgdU9fik5ORPz8WRh38SLEjh4BN4mvPsiDkFG5mLZwARYvW2rMGe2vUwW9lae/p6UV1Ru3oXn7HvToF+n8eq05o0zamY9HvzuclYbmKP3uMO9wiu8bmpeozUnLkCaXlJxsX7WhfEnG2ZzJ07IyUObqQFdsFFJGj0T+nNnGVFuyeIkxr1RG/0b6d4M6lAaSOp60r3E07dVZA0HtIoKT1iYC0m4BbY2QDHRPZCStTpqWzh0ZicCUhzb+Kr6gNzq0MK5wGpR6uqk09bRT8TQx6lzXFU/kqTbTFhFpSkpXm6O1wVkDQ9sqlKYzGflCpCSnNFRP5SmSEkGKnJWHyEa/Eqg6iTQVxmlbyUj1kikt2SiutL3+2l5xpZVpcd95aKN8RWYOwavMDllJPpKLiEkTieKqvM4bMMpfBOdoegqnp6zaeC5Zq8yajKUNKvyKFSvMuqrqpjZVWiqH9kA+88wzZjLS1iEpHYJvXR2oPDt37jR+PcFV/iJxkbqv0zXFVR6CntSLwHRPRC6ZOpC81T76UEdVZRXDNps2FYkLSkttobdipEErTfUFyVthJD/t1VT91JYiVMnrfOLsSVBkLdlKwCJDaYgJ8UiaNBGj5sxC9tRJGDl/LqbPn4fUzAzT8YU+DcIGEglWbtxiSLC7PxLkX++Pr+eQBO0fXzfoG9z8xkhsXCymTJ5yMgkKCh8VgYT8CRg3bQpyJk/ElAXzMWXWLKTbA/SkRP9Nca5IUINbg1T3ZcJpHcyZ0fW2gOI4mp46szQXkaDT1lrbU8dXXPn1tFObavVmiQhDMpdTnkpDBKJBqrc9VG6RgAi0Pygf5SviVNk14WqQiiikUamcviTo2wcV5nRIUNflRNYqmyASEtFqg7AGutKSTLRBW/XQwxvVW3UQMTikJwJVPJVbstFR8tQTcxGg1ju1F0/tIDkpbe3DU34qt7b7iBwlT8lKBKqtNSLBgOPNhkOCkpX8Il21hbbuOE7towdYIiLJUkelpXaUEyErX/UD9Q/JTPKTfEViZWWWTNVX1AZKT+mKLCUHhZEcHBJUWpoQFUeTh/qPZHw+cfYk6MjWIUPBqxkmII7aVbLW0VjpPmF8YZNg1aataNrBAdEvCUoTtEkw23oyretqX5O0E4hHV7fbNMTkKZPNbH0SFFblDA9FeHoqkjnjxDKcr5nWm+u/N0Qm6lwykzSQpE1p8AUaGCJBaXsKL1mIMB3iUXh1VJ07ZKlBKq1DYbX3S5tpdU9kJPNUM7lmew0MEZDuKbzSF+loEIvcZs6caQaj7os81WbSNEQoOmr9TQPF0WwCQfnIqZ4iArW/0hJxiFxUJpVdA8vRTBwojOojYtGgVBgRSyAZ+UL3FU75iHSVrrQdaUtKT3WVjDSgNZiVrtrA0ZhUHslIZKUySiaOpi0NSWugesNGSwEKo/yUlsKqXSUXOd0TkeqNGxGRZCp5D1R+tbMIV8QmuWmyVHv4Ol1T2tIUtSardlYdlYe0W8lU9ZRfYVQf1UuEmTc8TwIyxC+yk5OcpemrTmpLXVNYyUXtpfuSmdpQctEmekc7Pl/w/u7w6cKJdE5ootuDnooq7LnnAZT+7TG49Qv0PjTo5U56/H983fnWn28YeTrZUbKysnHH7bdj1OhRujOEcwh1Gw0QDXYNDGk2GkiBoLDOYJRfJKEBqM4tAjlT+KZ7OjjTeIOF0hehixhEJKqniENy6i9fxXHMZhGBJo2BTFmlr8lBxCHSkV9P3mVmajISeQ40YZwJfMshv5zaUeVW/VRPR/P0hVMvxVW9Ai1n+ELhNYmp/KcKey5wconPGmKhgREohJZ3uyVY69RLgIGgh8RqAH+YK05Eu5GGcHboT4bq0I6JJA2nPwIUfAew/Bow0mzOhgAF33RPB2cab7BQ+iIEaWLSniQfDeaB8tU9aYfSgCVTXwILFE9hpbEqXZGmtC1pkMpLr6+dD/LwLYf8cmpDlVdtGogABfUTlVXa42DKpfBK1wl7vsfxGZOgxHFy06iwjguMfoYUgkJCEREbg5CoSGvrCitutq7002/6uWzi9Xh6EMIGiWFaYZx9h3DmCDQA/TGYMEM4fxBJSHuSlqVtQlqGGGhSOlf4oNr9fOdzHsxh3TnNQisKzYaegmMofH0lDr31Lhr2HERoYzMi3R6EUQgmRYarjQhBt8zhOZO85rBTBX3iXuSn2VDrXrNmzcbosWMQOsDsY8U87RIPYQj/UtDShExkmdzSEocmpsHjQ10T9JKX02Dd1AFd1P9KK1C7cjV2vPoGqvYeABqaEN7lRiQ1vIaIUEOCVbMn4gRJMMj+BJZU5+TkJOSPG48ZM2dgGGfD4BCS3ykKOESCQxjC/zsQ5/hPEGdMgmcM5WbK4Es/PkWQV0USudU2oHLDZpx4Zx1qNm1Dd+FxVHe74MnNQtXcSShLjEFSTByy9cRv/FiMGz8emRlZCAkbjAnsm78/Bro3hCEM4f8P0PYlbT8655qgb2K993S1v5DOdd8w9BsipJfmMGrr4TlUiOObtmLzxo1oaG9D94yJSJw2EVMmTkJOdjYSkxIREno6i8GB8hcClWcIQxjC/9+gPZL6hNk5JUH/hKx7uuoQih3aOe0HeiRi3faJIzJs7wQqqtBWVg73sEyE52QOvP7hX8h+8/Upo++TmH6SHcIQhvDvBdFcYJ4A/j/HcGdmWQvaRgAAAABJRU5ErkJggg=="
                                }
                            }
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
