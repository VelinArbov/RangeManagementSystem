using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;
using Microsoft.Extensions.Logging;

namespace RangeManagementSystem.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly RangeManagementSystemDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ReservationController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {

            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public ActionResult Index(ReservationViewModel model)
        {
            CreateWeaponReservations(model);
            return Ok();
        }

        private void CreateWeaponReservations(ReservationViewModel model)
        {
            var id = _userManager.GetUserId(User);
            foreach (var item in model.Weapons)
            {
                var resr = new Reservation
                {
                    WeaponId = item.Key,
                    StartTime = model.StartDate,
                    EndTime = model.EndDate,
                    ApplicationUserId = id,
                };

                _dbContext.Reservations.Add(resr);
            }
            _dbContext.SaveChanges();
        }

        public ActionResult MyReservation(string id)
        {
            var reserv = _dbContext.Reservations.Where(x => x.ApplicationUserId == id).ToList();
            var mapped = _mapper.Map<List<ReservationDataViewModel>>(reserv);
            var model = new ReservationListViewModel { Reservations = mapped };
            return View(model);    
        }
    }
}
