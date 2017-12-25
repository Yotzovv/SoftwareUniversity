using Market.Data;
using Market.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider
                            .GetService<ApplicationDbContext>()
                            .Database
                            .Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminName = WebConstants.AdministratorRole;

                    var roles = new[]
                    {
                         adminName,
                    };

                    foreach (var role in roles)
                    {
                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });
                        }
                    }

                    var adminEmail = "admin@mysite.com";

                    var adminUser = await userManager.FindByEmailAsync(adminEmail);

                    if (adminUser == null)
                    {
                        adminUser = new ApplicationUser
                        {
                            UserName = adminName,
                            Email = adminEmail,
                            FirstName = adminName,
                            Birthdate = DateTime.UtcNow,
                            Country = "Adminia",
                            Area = "Vallhala",
                        };

                        await userManager.CreateAsync(adminUser, "Admin_12");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                }).Wait();
            }

            return app;
        }
    }
}
