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
            // Return only relevant ammo
            var ammo = _dbContext.Ammunitions.Where(x=> Weapons.Values.Contains(x.Type));
            var mappedAmmo = _mapper.Map<List<AmmunitionViewModel>>(ammo);
            mappedAmmo.ForEach(x =>
            {
                x.WeaponId = Weapons.Where(t => t.Value == x.Type).FirstOrDefault().Key;
            });
            var model = new ReservationViewModel
            {
                Weapons = Weapons,
                StartDate = startDate,
                EndDate = endDate,
                Ammunitions = mappedAmmo
            };
            return View(model);
        }

        public ActionResult AdminDashboard()
        {
            var dbWeapons = _dbContext.Ammunitions.ToList();
            var ammo = _mapper.Map<List<AmmunitionViewModel>>(dbWeapons);
            return View(new AmmunitionsViewModel { Ammunitions = ammo });
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
                        ReservationDate = DateTime.UtcNow,
                        AmmunitionId = item.Key,
                        StartTime = startDate,
                        EndTime = endDate,
                        Description = "Lorem ipsun",
                        ApplicationUserId = id,
                        WeaponId = int.Parse(item.Value)
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
