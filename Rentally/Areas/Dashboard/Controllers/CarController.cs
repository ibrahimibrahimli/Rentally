using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarCategoryService _carCategoryService ;

        public CarController(ICarCategoryService carCategoryService, ICarService carService)
        {

            _carCategoryService = carCategoryService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var data = _carService.GetCarWithCategory().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CarCategories"] = _carCategoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            var result = _carService.Add(car);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(car);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewData["CarCategories"] = _carCategoryService.GetAll().Data;

            var data = _carService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Car car)
        {
            var result = _carService.Update(car);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
