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
        CarCategoryManager _carCategoryManager = new();
        public IActionResult Index()
        {
            var data = _carCategoryManager.GetAll().Data;
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
            var result = _carCategoryManager.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _carCategoryManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(CarCategoryUpdateDto dto)
        {
            var result = _carCategoryManager.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _carCategoryManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
