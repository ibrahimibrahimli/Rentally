using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TestimonialCreateDto dto)
        {
            var result = _testimonialService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(TestimonialUpdateDto dto)
        {
            var result = _testimonialService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _testimonialService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
