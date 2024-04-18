using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;

namespace RangeManagementSystem.Web.Controllers
{
    public class AmmonutionController : Controller
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AmmonutionController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        // GET: AmmonutionController
        public ActionResult Index(DateTime startDate, DateTime endDate, Dictionary<int, string> Weapons)
        {
            var weaponTypes = Weapons.Values;
            var ammoForSelectedWeapons = _dbContext.Ammunitions.Where(x => weaponTypes.Contains(x.Type)).ToList();
            var mappedAmmo = _mapper.Map<List<AmmunitionViewModel>>(ammoForSelectedWeapons);
            foreach (var ammo in mappedAmmo)
            {              
                if (Weapons.Values.Contains(ammo.Type))
                {
                    ammo.WeaponId = Weapons.FirstOrDefault(x => x.Value == ammo.Type).Key;
                }
            }

            var model = new ReservationViewModel
            {            
                Weapons = Weapons,
                StartDate = startDate,
                EndDate = endDate,
                Ammunitions = mappedAmmo
            };
            return View(model);
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Reserve(Dictionary<int, string> selectedProducts, DateTime startDate, DateTime endDate)
        {
            if (selectedProducts.Count > 0)
            {
                var id = _userManager.GetUserId(User);
                foreach (var item in selectedProducts)
                {
                    var resr = new Reservation
                    {
                        WeaponId = item.Key,
                        StartTime = startDate,
                        EndTime = endDate,
                        Description = "Lorem ipsun",
                        ApplicationUserId = id,
                        AmmunitionId = int.Parse(item.Value)
                    };

                    _dbContext.Reservations.Add(resr);
                }
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Ammonution", new ReservationViewModel { Weapons = selectedProducts, StartDate = startDate, EndDate = endDate });
            }
            return Ok();
        }

    }
}
