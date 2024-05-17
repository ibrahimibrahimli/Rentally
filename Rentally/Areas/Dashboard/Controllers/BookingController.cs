using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BookingController : Controller
    {
        BookingManager _bookingManager = new();
        UserManager _userManager = new();
        CarManager _carManager = new();
        public IActionResult Index()
        {
            var data = _bookingManager.GetTeamBoardWithPosition().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Users"] = _userManager.GetAll().Data;
            ViewData["Cars"] = _carManager.GetCarWithCategory().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            var result = _bookingManager.Add(booking);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(booking);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Users"] = _userManager.GetAll().Data;
            ViewData["Cars"] = _carManager.GetCarWithCategory().Data;
            var data = _bookingManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Booking booking)
        {
            var result = _bookingManager.Update(booking);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(booking);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _bookingManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
