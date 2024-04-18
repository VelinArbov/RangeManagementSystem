using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Controllers
{
    public class WeaponController : Controller
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public WeaponController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        // GET: WeaponController
        public ActionResult Index()
        {
            var dbWeapons = _dbContext.Weapons.ToList();
            var weapons = _mapper.Map<List<WeaponViewModel>>(dbWeapons);
            return View(new WeaponsViewModel { Weapons = weapons });
        }

        // POST: WeaponController/Reserve
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve(Dictionary<int, string> selectedProducts, DateTime startDate, DateTime endDate )
        {
            if (selectedProducts.Count > 0)
            {
                return RedirectToAction("Index", "Ammonution", new ReservationViewModel { Weapons = selectedProducts, StartDate = startDate, EndDate = endDate });
            }
            return Ok();
        }

    }
}
