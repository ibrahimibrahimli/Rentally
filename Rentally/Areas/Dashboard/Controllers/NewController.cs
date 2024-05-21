using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class NewController : Controller
    {
        private readonly INewService _newService;

        public NewController(INewService newService)
        {
            _newService = newService;
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
        public IActionResult Create(NewCreateDto dto)
        {
            var result = _newService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _newService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(NewUpdateDto dto)
        {
            var result = _newService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
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
