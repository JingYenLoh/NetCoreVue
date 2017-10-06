using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Helpers
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();

            db.Database.Migrate();

            var identityRoleStore = new RoleStore<IdentityRole>(db);
            var identityRoleManager = new RoleManager<IdentityRole>(identityRoleStore, null, null, null, null);

            //Defining user "roles" inside the AspNetRoles table.
            var adminRole = new IdentityRole {Name = "Admin"};
            await identityRoleManager.CreateAsync(adminRole);

            var officerRole = new IdentityRole {Name = "Instructor"};
            await identityRoleManager.CreateAsync(officerRole);

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager =
                new UserManager<ApplicationUser>(userStore, null, null, null, null, null, null, null, null);
            var ph = new PasswordHasher<ApplicationUser>();

            var kenny = new ApplicationUser
            {
                UserName = "88881",
                Email = "kenny@fairyschool.com",
                FullName = "Kenny"
            };
            kenny.PasswordHash = ph.HashPassword(kenny, "P@ssw0rd");
            await userManager.CreateAsync(kenny);
            await userManager.AddToRoleAsync(kenny, "Admin");

            var juliet = new ApplicationUser
            {
                UserName = "88882",
                Email = "juliet@fairyschool.com",
                FullName = "Juliet"
            };
            juliet.PasswordHash = ph.HashPassword(juliet, "P@ssw0rd");
            await userManager.CreateAsync(juliet);
            await userManager.AddToRoleAsync(juliet, "Admin");

            var randy = new ApplicationUser
            {
                UserName = "88883",
                Email = "randy@hotinstructor.com",
                FullName = "Randy"
            };
            randy.PasswordHash = ph.HashPassword(randy, "P@ssw0rd");
            await userManager.CreateAsync(randy);
            await userManager.AddToRoleAsync(randy, "Instructor");

            var thomas = new ApplicationUser
            {
                UserName = "88884",
                Email = "thomas@hotinstructor.com",
                FullName = "Thomas"
            };
            thomas.PasswordHash = ph.HashPassword(thomas, "P@ssw0rd");
            await userManager.CreateAsync(thomas);
            await userManager.AddToRoleAsync(thomas, "Instructor");

            var ben = new ApplicationUser
            {
                UserName = "88885",
                Email = "ben@hotinstructor.com",
                FullName = "Ben"
            };
            ben.PasswordHash = ph.HashPassword(ben, "P@ssw0rd");
            await userManager.CreateAsync(ben);
            await userManager.AddToRoleAsync(ben, "Instructor");

            var gabriel = new ApplicationUser
            {
                UserName = "88886",
                Email = "gabriel@hotinstructor.com",
                FullName = "Gabriel"
            };
            gabriel.PasswordHash = ph.HashPassword(gabriel, "P@ssw0rd");
            await userManager.CreateAsync(gabriel);
            await userManager.AddToRoleAsync(gabriel, "Instructor");

            var fred = new ApplicationUser
            {
                UserName = "88887",
                Email = "fred@hotinstructor.com",
                FullName = "Fred"
            };
            fred.PasswordHash = ph.HashPassword(fred, "P@ssw0rd");
            await userManager.CreateAsync(fred);
            await userManager.AddToRoleAsync(fred, "Instructor");

            db.SaveChanges();
        }
    }
}