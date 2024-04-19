using Microsoft.AspNetCore.Mvc;

namespace RangeManagementSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
