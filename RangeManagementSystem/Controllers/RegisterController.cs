using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RangeManagementSystem.Data;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Web.Models;
using RangeManagementSystem.Web.Services.Register;

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
        public ActionResult Index()
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


                }
            }
            return View("Index");
        }
    }
}
