using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }
  
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,true, lockoutOnFailure: true);
                var user = await this._userManager.FindByNameAsync(model.Username);
                if(result.Succeeded && user != null)
                {
                    if (user.IsAdmin)
                    {

                    }
                    else
                    {

                    }
                }
            }
            return View("Index");
        }
    }
}
