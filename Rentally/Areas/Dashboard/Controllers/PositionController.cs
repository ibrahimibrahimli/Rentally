using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PositionController : Controller
    {
        PositionManager _positionManager = new();
        public IActionResult Index()
        {
            var data = _positionManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            var result = _positionManager.Add(position);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(position);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _positionManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Position position)
        {
            var result = _positionManager.Update(position);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(position);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _positionManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
