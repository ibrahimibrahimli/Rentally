using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class NewController : Controller
    {
        private readonly INewService _newService;
        private readonly IWebHostEnvironment _env;

        public NewController(INewService newService,IWebHostEnvironment hostEnvironment)
        {
            _newService = newService;
            _env = hostEnvironment;
        }
        public IActionResult Index()
        {
            var data = _newService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewCreateDto dto, IFormFile ImageUrl)
        {
            var result = _newService.Add(dto, ImageUrl, _env.WebRootPath);
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
            var data = _newService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(NewUpdateDto dto, IFormFile imageUrl)
        {
            var result = _newService.Update(dto, imageUrl, _env.WebRootPath);
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
            var result = _newService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
