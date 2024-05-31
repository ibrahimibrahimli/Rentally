using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;
        public BookingController(ICarService carService, IBookingService bookingService, IUserService userService)
        {
            _carService = carService;
            _bookingService = bookingService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var data = _bookingService.GetTeamBoardWithPosition().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Users"] = _userService.GetAll().Data;
            ViewData["Cars"] = _carService.GetCarWithCategory().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookingCreateDto dto)
        {
            var result = _bookingService.Add(dto);
            if (!result.IsSuccess)
            {
                ViewData["Users"] = _userService.GetAll().Data;
                ViewData["Cars"] = _carService.GetCarWithCategory().Data;
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Users"] = _userService.GetAll().Data;
            ViewData["Cars"] = _carService.GetCarWithCategory().Data;
            var data = _bookingService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(BookingUpdateDto dto)
        {
            var result = _bookingService.Update(dto);


            if (!result.IsSuccess)
            {
                ViewData["Users"] = _userService.GetAll().Data;
                ViewData["Cars"] = _carService.GetCarWithCategory().Data;
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }
            return RedirectToAction("Index");
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
