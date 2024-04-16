namespace RangeManagementSystem.Data
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(RangeManagementSystemDbContext dbContext, IServiceProvider serviceProvider);
    }
}
