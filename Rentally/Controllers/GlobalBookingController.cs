using Business.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.ViewModels;

namespace Rentally.WEB.Controllers
{
    public class GlobalBookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;
        private readonly IRegionService _regionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public GlobalBookingController(IBookingService bookingService, ICarService carService, UserManager<ApplicationUser> userManager, IRegionService regionService)
        {
            _bookingService = bookingService;
            _carService = carService;
            _userManager = userManager;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = _carService.GetCarWithCategory().Data;
            var user = await _userManager.GetUserAsync(User);
            var regions = _regionService.GetAll().Data;
            BookingCreateDto booking = new();

            BookingViewModel bookingViewModel = new()
            {
                Cars = cars,
                User = user,
                Regions = regions,
                Bookings = booking 
            };
            
            return View(bookingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel model) 
        {
            var user = await _userManager.GetUserAsync (User);
            model.Bookings.UserId = user.Id;

            var result = _bookingService.Add(model.Bookings);

            if (result.IsSuccess)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}
