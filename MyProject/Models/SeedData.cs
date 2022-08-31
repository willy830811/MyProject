using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.Models
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("willy830811@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "willy830811@gmail.com",
                    Email = "willy830811@gmail.com",
                    NormalizedUserName = "WILLY830811@GMAIL.COM",
                    NormalizedEmail = "WILLY830811@GMAIL.COM"
                };

                var password = ".Aa123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "最高管理者").Wait();
                }
            }

            if (userManager.FindByNameAsync("willy830811@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test1@gmail.com",
                    Email = "test1@gmail.com",
                    NormalizedUserName = "TEST1@GMAIL.COM",
                    NormalizedEmail = "TEST1@GMAIL.COM"
                };

                var password = ".Aa123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "組長").Wait();
                }
            }

            if (userManager.FindByNameAsync("willy830811@gmail.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test2@gmail.com",
                    Email = "test2@gmail.com",
                    NormalizedUserName = "TEST2@GMAIL.COM",
                    NormalizedEmail = "TEST2@GMAIL.COM"
                };

                var password = ".Aa123456";

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "組員").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("最高管理者").Result)
            {
                var role = new IdentityRole
                {
                    Name = "最高管理者"
                };

                roleManager.CreateAsync(role).Wait();
            }

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
            }
        }
    }
}
