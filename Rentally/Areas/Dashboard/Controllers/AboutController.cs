using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutController : Controller
    {
        AboutManager _aboutService = new();
        public IActionResult Index()
        {
            
            var data = _aboutService.GetAboutWithCarCustomerBooking().Data;
            ViewBag.ShowButton = data.Count() == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutCreateDto dto)
        {
            var result = _aboutService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _aboutService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(AboutUpdateDto dto)
        {
            var result = _aboutService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }
    }
}
