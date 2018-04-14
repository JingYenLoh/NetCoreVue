using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Helpers
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check for roles
                if (context.Users.Any())
                {
                    return; // Db is seeded with users
                }
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);

                //Defining user "roles" inside the AspNetRoles table.
                var adminRole = new IdentityRole { Name = "Admin" };
                await roleManager.CreateAsync(adminRole);

                var officerRole = new IdentityRole { Name = "Instructor" };
                await roleManager.CreateAsync(officerRole);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager =
                    new UserManager<ApplicationUser>(userStore, null, null, null, null, null, null, null, null);
                var hasher = new PasswordHasher<ApplicationUser>();

                #region kenny

                var kenny = new ApplicationUser
                {
                    UserName = "88881",
                    Email = "kenny@fairyschool.com",
                    FullName = "Kenny"
                };
                kenny.PasswordHash = hasher.HashPassword(kenny, "P@ssw0rd");
                await userManager.CreateAsync(kenny);
                await userManager.AddToRoleAsync(kenny, "Admin");

                var userInfoKenny = new UserInfo
                {
                    FullName = kenny.FullName,
                    LoginUserName = kenny.UserName,
                    Email = kenny.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoKenny);

                #endregion

                #region juliet

                var juliet = new ApplicationUser
                {
                    UserName = "88882",
                    Email = "juliet@fairyschool.com",
                    FullName = "Juliet"
                };
                juliet.PasswordHash = hasher.HashPassword(juliet, "P@ssw0rd");
                await userManager.CreateAsync(juliet);
                await userManager.AddToRoleAsync(juliet, "Admin");

                var userInfoJuliet = new UserInfo
                {
                    FullName = juliet.FullName,
                    LoginUserName = juliet.UserName,
                    Email = juliet.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoJuliet);
                
                #endregion

                #region randy

                var randy = new ApplicationUser
                {
                    UserName = "88883",
                    Email = "randy@hotinstructor.com",
                    FullName = "Randy"
                };
                randy.PasswordHash = hasher.HashPassword(randy, "P@ssw0rd");
                await userManager.CreateAsync(randy);
                await userManager.AddToRoleAsync(randy, "Instructor");

                var userInfoRandy = new UserInfo
                {
                    FullName = randy.FullName,
                    LoginUserName = randy.UserName,
                    Email = randy.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoRandy);

                #endregion

                #region thomas

                var thomas = new ApplicationUser
                {
                    UserName = "88884",
                    Email = "thomas@hotinstructor.com",
                    FullName = "Thomas"
                };
                thomas.PasswordHash = hasher.HashPassword(thomas, "P@ssw0rd");
                await userManager.CreateAsync(thomas);
                await userManager.AddToRoleAsync(thomas, "Instructor");

                var userInfoThomas = new UserInfo
                {
                    FullName = thomas.FullName,
                    LoginUserName = thomas.UserName,
                    Email = thomas.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoThomas);

                #endregion

                #region ben

                var ben = new ApplicationUser
                {
                    UserName = "88885",
                    Email = "ben@hotinstructor.com",
                    FullName = "Ben"
                };
                ben.PasswordHash = hasher.HashPassword(ben, "P@ssw0rd");
                await userManager.CreateAsync(ben);
                await userManager.AddToRoleAsync(ben, "Instructor");

                var userInfoBen = new UserInfo
                {
                    FullName = ben.FullName,
                    LoginUserName = ben.UserName,
                    Email = ben.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoBen);

                #endregion

                #region gabriel

                var gabriel = new ApplicationUser
                {
                    UserName = "88886",
                    Email = "gabriel@hotinstructor.com",
                    FullName = "Gabriel"
                };
                gabriel.PasswordHash = hasher.HashPassword(gabriel, "P@ssw0rd");
                await userManager.CreateAsync(gabriel);
                await userManager.AddToRoleAsync(gabriel, "Instructor");

                var userInfoGabriel = new UserInfo
                {
                    FullName = gabriel.FullName,
                    LoginUserName = gabriel.UserName,
                    Email = gabriel.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoGabriel);

                #endregion

                #region fred

                var fred = new ApplicationUser
                {
                    UserName = "88887",
                    Email = "fred@hotinstructor.com",
                    FullName = "Fred"
                };
                fred.PasswordHash = hasher.HashPassword(fred, "P@ssw0rd");
                await userManager.CreateAsync(fred);
                await userManager.AddToRoleAsync(fred, "Instructor");

                var userInfoFred = new UserInfo
                {
                    FullName = fred.FullName,
                    LoginUserName = fred.UserName,
                    Email = fred.Email,
                    IsActive = true
                };
                context.UserInfo.Add(userInfoFred);

                #endregion
                
                context.SaveChanges();
            }
        }
    }
}