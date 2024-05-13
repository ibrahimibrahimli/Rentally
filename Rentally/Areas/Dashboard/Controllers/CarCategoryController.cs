using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.TableModels;

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
        public IActionResult Create(CarCategory carCategory)
        {
            var result = _carCategoryManager.Add(carCategory);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(carCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _carCategoryManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(CarCategory carCategory)
        {
            var result = _carCategoryManager.Update(carCategory);

            if (result.IsSuccess) return RedirectToAction("index");

            return View(carCategory);
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
