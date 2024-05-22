using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Core.Extensions;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarCategoryService _carCategoryService ;
        private readonly IWebHostEnvironment _env;

        public CarController(ICarCategoryService carCategoryService, ICarService carService, IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;  
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
        public IActionResult Create(Car car, IFormFile imageUrl)
        {
            var result = _carService.Add(car, imageUrl, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                ViewData["CarCategories"] = _carCategoryService.GetAll().Data;
                ModelState.AddModelError("", result.Message);

                return View(car);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewData["CarCategories"] = _carCategoryService.GetAll().Data;

            var data = _carService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Car car, IFormFile imageUrl)
        {
            var result = _carService.Update(car, imageUrl, _env.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(car);
            }
            return RedirectToAction("Index");
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
