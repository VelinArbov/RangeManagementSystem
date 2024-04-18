namespace RangeManagementSystem.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using RangeManagementSystem.Data.Models;

    public class UserRolesSeeder : ISeeder
    {
        public async Task SeedAsync(RangeManagementSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            var user = await userManager.FindByNameAsync("Admin");
            var role = await roleManager.FindByNameAsync("Admin");

            if (user != null && role != null)
            {
                var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

                if (exists)
                {
                    return;
                }
                else
                {
                    user.IsAdmin = true;

                    dbContext.UserRoles.Add(new IdentityUserRole<string>
                    {
                        RoleId = role.Id,
                        UserId = user.Id,
                    });

                    await dbContext.SaveChangesAsync();
                }
            }

            return;
        }
    }
}
