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

        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Ammunition> Ammunitions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ShootingEvent> ShootingEvents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
