using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Web.Models;
using System.Security.Claims;

namespace RangeManagementSystem.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: RegisterController
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Login
                    var check = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: true);
                    var newUser = await this._userManager.FindByNameAsync(model.Username);
                    if (result.Succeeded && user != null)
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        ViewData["UserId"] = userId;
                        return RedirectToAction("Dashboard", "Client");
                    }
                }
            }
            return View("Index");
        }
    }
}
