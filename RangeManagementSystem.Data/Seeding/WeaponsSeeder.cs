using RangeManagementSystem.Data.Models;

namespace RangeManagementSystem.Data
{
    internal class WeaponsSeeder : ISeeder
    {
        public async Task SeedAsync(RangeManagementSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Weapons.Any())
            {
                return;
            }

            await dbContext.Weapons.AddRangeAsync(WeaponGenerator());

        }

        private List<Weapon> WeaponGenerator()
        {
            var weapons = new List<Weapon>();
            var random = new Random();
            var types = new[] { "Pistol", "Rifle", "Shotgun" };
            var calibers = new[] { "25", "9mm", "5.56mm", "12 Gauge" };

            for (int i = 0; i < 20; i++)
            {
                weapons.Add(new Weapon
                {
                    Type = types[random.Next(types.Length)],
                    Caliber = calibers[random.Next(calibers.Length)],
                    Quantity = random.Next(1, 1000),
                    Availability = random.Next(2) == 0
                });
            } return weapons;
        }
    }
}
