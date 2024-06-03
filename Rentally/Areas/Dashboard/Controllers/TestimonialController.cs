using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(ITestimonialService testimonialService, IWebHostEnvironment hostEnvironment)
        {
            _testimonialService = testimonialService;
            _env = hostEnvironment;
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
        public IActionResult Create(TestimonialCreateDto dto, IFormFile ImageUrl)
        {
            var result = _testimonialService.Add(dto, ImageUrl, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(TestimonialUpdateDto dto, IFormFile imageUrl)
        {
            var result = _testimonialService.Update(dto, imageUrl, _env.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }
            return RedirectToAction("Index");
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
