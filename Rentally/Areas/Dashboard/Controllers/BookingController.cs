using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BookingController : Controller
    {
        UserManager _userManager = new();
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;
        public BookingController(ICarService carService, IBookingService bookingService)
        {
            _carService = carService;
            _bookingService = bookingService;
        }
        public IActionResult Index()
        {
            var data = _bookingService.GetTeamBoardWithPosition().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Users"] = _userManager.GetAll().Data;
            ViewData["Cars"] = _carService.GetCarWithCategory().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookingCreateDto dto)
        {
            var result = _bookingService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Users"] = _userManager.GetAll().Data;
            ViewData["Cars"] = _carService.GetCarWithCategory().Data;
            var data = _bookingService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(BookingUpdateDto dto)
        {
            var result = _bookingService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _bookingService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
