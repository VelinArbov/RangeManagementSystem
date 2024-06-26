﻿using RangeManagementSystem.Data.Models;

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
            var types = new[] { "FMJ", "JHP", "AP", "Tracer", "Shotgun", "Rifle", "Pistol" };
            var calibers = new[] { "9mm", "5.56mm", "7.62mm", ".45 ACP", ".308", ".50 BMG", "12 gauge" };

            for (int i = 0; i < 10; i++)
            {
                weapons.Add(new Weapon
                {
                    Type = types[random.Next(types.Length)],
                    Caliber = calibers[random.Next(calibers.Length)],
                    Quantity = random.Next(1, 10),
                    Availability = random.Next(2) == 0
                });
            } return weapons;
        }
    }
}
