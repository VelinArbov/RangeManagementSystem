using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(RegisterInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                //var result = await _userManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{


                //}
            }
            return View("Index");
        }
    }
}
