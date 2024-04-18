using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RangeManagementSystem.Data.Models;

namespace RangeManagementSystem.Data
{
    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(RangeManagementSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (!userManager.Users.ToList().Any())
            {
                // Check if the administrator user exists
                var adminUser = await userManager.FindByEmailAsync("admin@example.com");
                if (adminUser == null)
                {
                    // Create the administrator user
                    adminUser = new ApplicationUser
                    {
                        UserName = "Admin",
                        Email = "admin@example.com",
                        IsAdmin = true,
                        // You can add additional properties here
                    };
                    var result = await userManager.CreateAsync(adminUser, "AdminPassword123!"); // Change the password
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Failed to create administrator user: {result.Errors}");
                    }
                }
                var simpleUser = new ApplicationUser
                {
                    UserName = "User",
                    Email = "user@example.com",
                    IsAdmin = false
                };
                var newUser = await userManager.CreateAsync(simpleUser, "AdminPassword1234!"); // Change the password
                if (!newUser.Succeeded)
                {
                    throw new Exception($"Failed to create administrator user: {newUser.Errors}");
                }
                // You can seed other users similarly if needed
            }
        }
    }
}
