using RangeManagementSystem.Data.Models;

namespace RangeManagementSystem.Data
{
    internal class AmmoSeeder : ISeeder
    {
        public async Task SeedAsync(RangeManagementSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Ammunitions.Any())
            {
                return;
            }

            await dbContext.Ammunitions.AddRangeAsync(AmmoGenerator());

        }

        private List<Ammunition> AmmoGenerator()
        {
            var ammo = new List<Ammunition>();
            var random = new Random();
            var types = new[] { "FMJ", "JHP", "AP", "Tracer", "Shotgun", "Rifle", "Pistol" };
            var calibers = new[] { "25", "9mm", "5.56mm", "12 Gauge" };

            for (int i = 0; i < 10; i++)
            {
                ammo.Add(new Ammunition
                {
                    Type = types[random.Next(types.Length)],
                    Caliber = calibers[random.Next(calibers.Length)],
                    Quantity = random.Next(1, 10),
                    Availability = random.Next(2) == 0
                });
            } 
            return ammo;
        }
    }
}
