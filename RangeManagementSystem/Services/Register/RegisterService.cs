using Microsoft.AspNetCore.Identity;
using RangeManagementSystem.Data;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterService(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task Register(RegisterInputViewModel model)
        {
            var c = new Ammunition
            {
                Id= 2,
                Type = "ysdas",
                Quantity = 1,
                Caliber = "test"
            };

            _dbContext.Ammunitions.Add(c);
            //await _dbContext.SaveChangesAsync();



            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                Console.WriteLine("test");
                //await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("fasdasdasd");
            }
           
        }
    }
}
