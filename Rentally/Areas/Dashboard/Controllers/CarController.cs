using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarController : Controller
    {
        CarManager _carManager = new();
        CarCategoryManager _carCategoryManager = new();
        public IActionResult Index()
        {
            var data = _carManager.GetCarWithCategory().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CarCategories"] = _carCategoryManager.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            var result = _carManager.Add(car);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(car);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewData["CarCategories"] = _carCategoryManager.GetAll().Data;

            var data = _carManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Car car)
        {
            var result = _carManager.Update(car);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _carManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
