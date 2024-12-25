using Business.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.ViewModels;

namespace Rentally.WEB.Controllers
{
    public class GlobalBookingController : BaseController
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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var cars = _carService.GetCarWithCategory().Data;
            var user = await _userManager.GetUserAsync(User);
            var regions = _regionService.GetAll().Data;
            BookingCreateDto booking = new();

            BookingViewModel bookingViewModel = new()
            {
                Cars = cars,
                Bookings = booking ,
                User = user,
                Regions = regions
            };
            
            return View(bookingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel model) 
        {
            var user = await _userManager.GetUserAsync(User);
            model.Bookings.UserId = user.Id;

            var result = _bookingService.Add(model.Bookings);

            if (result.IsSuccess)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SingleCreate(int Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var regions = _regionService.GetAll().Data;
            BookingCreateDto booking = new();
            var car = _carService.GetById(Id).Data;

            BookingViewModel bookingViewModel = new()
            {
                SingleCar = car,
                User = user,
                Regions = regions,
                Bookings = booking
            };

            return View(bookingViewModel);
        }


    }
}
