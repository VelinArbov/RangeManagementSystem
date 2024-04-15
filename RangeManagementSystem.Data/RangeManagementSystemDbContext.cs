using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RangeManagementSystem.Data.Models;

namespace RangeManagementSystem.Data
{
    public class RangeManagementSystemDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public RangeManagementSystemDbContext(DbContextOptions<RangeManagementSystemDbContext> options)
         : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
