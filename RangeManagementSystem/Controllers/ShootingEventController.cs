using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace RangeManagementSystem.Web.Controllers
{
    public class ShootingEventController : Controller
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ShootingEventController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: ShootingEvent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            var userId = _userManager.GetUserId(User);
            var shootingEvents = _dbContext.ShootingEvents
            .Include(e => e.ApplicationUser)
            .Where(e => e.EndTime >= DateTime.Today)
            .ToList();
            var events = _mapper.Map<List<ShootingEventViewModel>>(shootingEvents);
            return View(new ShootingEventsViewModel { Events = events});
        }

        // POST: ShootingEvent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShootingEventCreateViewModel model)
        {
            if (!ModelState.IsValid || model.StartDate > model.EndDate || model.MaxParticipants < model.MinParticipants)
            {
                if (model.StartDate > model.EndDate)
                    ModelState.AddModelError("StartDate", "Началната дата трябва да бъде преди крайната дата.");
                if (model.MaxParticipants < model.MinParticipants)
                    ModelState.AddModelError("MinParticipants", "Минималният брой участници трябва да бъде по-малък или равен от максималния.");
            }
            else
            {
                var userId = _userManager.GetUserId(User);
                _dbContext.ShootingEvents.Add(new ShootingEvent
                {
                    EventDate = DateTime.UtcNow,
                    StartTime = model.StartDate,
                    EndTime = model.EndDate,
                    MinParticipants = model.MinParticipants,
                    MaxParticipants = model.MaxParticipants,
                    Description =  "Lorem ipsum",
                    ApplicationUserId = userId
                });
                _dbContext.SaveChanges();
                model.SuccessMessage = "Заявката за организиране на стрелбата е успешна. Очакваме участници!";
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> JoinEvents(string selectedEventIds)
        {
            if(!string.IsNullOrEmpty(selectedEventIds))
            {
                var eventIds = selectedEventIds.Split(',').ToList();
                var events = _dbContext.ShootingEvents.Where(x => eventIds.Contains(x.Id.ToString())).ToList(); 
                var applicationUser = await _userManager.GetUserAsync(User);
                applicationUser.ShootingEvents.AddRange(events);
                _dbContext.SaveChanges(true);

                return View("Index");
            }
            return View("Index");
        }

        // POST: ShootingEvent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShootingEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShootingEvent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
