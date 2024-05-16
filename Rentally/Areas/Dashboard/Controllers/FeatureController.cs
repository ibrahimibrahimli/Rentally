using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FeatureController : Controller
    {
        FeatureManager _featureManager = new();
        public IActionResult Index()
        {
            var data = _featureManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            var result = _featureManager.Add(feature);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(feature);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _featureManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Feature feature)
        {
            var result = _featureManager.Update(feature);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(feature);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _featureManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
