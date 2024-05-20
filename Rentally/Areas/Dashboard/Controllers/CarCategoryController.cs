using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Entities.Concrete.Dtos;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarCategoryController : Controller
    {
        private readonly ICarCategoryService _carCategoryService;
        public CarCategoryController(ICarCategoryService carCategoryService)
        {
            _carCategoryService = carCategoryService;
        }

        public IActionResult Index()
        {
            var data = _carCategoryService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarCategoryCreateDto dto)
        {
            var result = _carCategoryService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _carCategoryService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(CarCategoryUpdateDto dto)
        {
            var result = _carCategoryService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _carCategoryService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
