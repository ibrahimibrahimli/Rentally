using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class NewController : Controller
    {
        NewManager _newManager = new();
        public IActionResult Index()
        {
            var data = _newManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(New New)
        {
            var result = _newManager.Add(New);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(New);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _newManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(New New)
        {
            var result = _newManager.Update(New);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(New);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _newManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
