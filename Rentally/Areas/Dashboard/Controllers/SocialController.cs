using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SocialController : Controller
    {
        SocialManager _socialManager = new();
        public IActionResult Index()
        {
            var data = _socialManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Social social)
        {
            var result = _socialManager.Add(social);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(social);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _socialManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(Social social)
        {
            var result = _socialManager.Update(social);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(social);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _socialManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
