using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
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

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }

            return RedirectToAction("Index");
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

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }
            return RedirectToAction("Index");
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
