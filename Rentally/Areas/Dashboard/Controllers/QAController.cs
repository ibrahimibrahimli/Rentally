using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class QAController : Controller
    {
        QAManager _qaManager = new();

        public IActionResult Index()
        {
            var data = _qaManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QA QA)
        {
            var result = _qaManager.Add(QA);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(QA);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _qaManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(QA QA)
        {
            var result = _qaManager.Update(QA);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(QA);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _qaManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}

