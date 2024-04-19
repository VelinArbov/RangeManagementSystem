using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RangeManagementSystem.Web.Controllers
{
    [Authorize]
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
        public ActionResult Reserve(Dictionary<int, string> selectedProducts, DateTime startDate, DateTime endDate)
        {
            if (selectedProducts.Count > 0)
            {
                // Construct the URL with query string parameters
                var url = Url.Action("Index", "Ammonution", new { startDate, endDate });

                // Append selected products as query string parameters
                foreach (var item in selectedProducts)
                {
                    url += $"&Weapons[{item.Key}]={HttpUtility.UrlEncode(item.Value)}";
                }

                // Redirect to the constructed URL
                return Redirect(url);
            }

            // Handle the case where no products are selected
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        // GET: WeaponController
        public ActionResult AdminDashboard()
        {
            var dbWeapons = _dbContext.Weapons.ToList();
            var weapons = _mapper.Map<List<WeaponViewModel>>(dbWeapons);
            return View(new WeaponsViewModel { Weapons = weapons });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeaponCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var weapon = _mapper.Map<Weapon>(model);
                var dbWeapons = _dbContext.Weapons.Add(weapon);
                _dbContext.SaveChanges();
                return this.RedirectToAction("AdminDashboard");
            }
            return this.View();
        }

        // POST: WeaponController/Reserve
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dictionary<int, string> selectedProducts)
        {
            if (selectedProducts.Count > 0)
            {
                var weapon = _dbContext.Weapons.FirstOrDefault(x => x.Id == selectedProducts.First().Key);
                var mapped = _mapper.Map<WeaponEditViewModel>(weapon);
                return View("Edit", mapped);
            }

            // Handle the case where no products are selected
            return RedirectToAction("Index", "Home");
        }

        // POST: WeaponController/Reserve
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAction(WeaponEditViewModel model)
        {
            var mapped = _mapper.Map<Weapon>(model);
            _dbContext.Weapons.Update(mapped);
            _dbContext.SaveChanges();
            return this.RedirectToAction("AdminDashboard");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var weaponToDelete = _dbContext.Weapons.Find(id);

            if (weaponToDelete != null)
            {
                // Remove the entity from the context
                _dbContext.Weapons.Remove(weaponToDelete);

                // Save changes to persist the deletion
                _dbContext.SaveChanges();
            }
            else
            {
                // Handle the case when the entity with the specified ID doesn't exist
                return NotFound();
            }

            // Redirect to a success page or perform any other action
            return View("Dashboard", "Admin");
        }
    }
}
