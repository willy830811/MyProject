using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.Models
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("willy830811@gmail.com").Result == null)
            {
                var user = new IdentityUser
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
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
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
                            City = "111",
                            Region = "111",
                            Section = "泰山段二小段",
                            Number = "0139-0000",
                            RegisterReason = 1,
                            Order = 1,
                            Area = 1.23F,
                            OwnerId = 99,
                            RegisterTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            CreateTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            CreateId = 99,
                            UpdateTime = Convert.ToDateTime("2022-01-01 00:00:00"),
                            UpdateId = 99
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
