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
    public class QAController : Controller
    {
        private readonly IQAService _iQaService;

        public QAController(IQAService qAService)
        {
            _iQaService = qAService;
        }

        public IActionResult Index()
        {
            var data = _iQaService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QuestionAnswerCreateDto dto)
        {
            var result = _iQaService.Add(dto);
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
            var data = _iQaService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(QuestionAnswerUpdateDto dto)
        {
            var result = _iQaService.Update(dto);

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
            var result = _iQaService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}

