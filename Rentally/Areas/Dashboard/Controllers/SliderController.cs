using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;
        public SliderController(ISliderService sliderService, IWebHostEnvironment hostEnvironment)
        {
            _sliderService = sliderService;
            _env = hostEnvironment;
        }
        public IActionResult Index()
        {
            var data = _sliderService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SliderCreateDto dto, IFormFile ImageUrl)
        {
            var result = _sliderService.Add(dto, ImageUrl, _env.WebRootPath);
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
            var data = _sliderService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(SliderUpdateDto dto, IFormFile imageUrl)
        {
            var result = _sliderService.Update(dto, imageUrl, _env.WebRootPath);

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
            var result = _sliderService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
