using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SliderController : Controller
    {
        SliderManager _sliderManager = new();
        public IActionResult Index()
        {
            var data = _sliderManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            var result = _sliderManager.Add(slider);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(slider);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _sliderManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Slider slider)
        {
            var result = _sliderManager.Update(slider);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(slider);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _sliderManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
