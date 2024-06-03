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
    public class TeamBoardController : Controller
    {
        private readonly ITeamBoardService _teamBoardService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _env;

        public TeamBoardController(ITeamBoardService teamBoardService, IPositionService positionService, IWebHostEnvironment hostEnvironment)
        {
            _teamBoardService = teamBoardService;
            _positionService = positionService;
            _env = hostEnvironment;
        }
        public IActionResult Index()
        {
            var data = _teamBoardService.GetTeamBoardWithPosition().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamBoardCreateDto dto, IFormFile ImageUrl)
        {
            var result = _teamBoardService.Add(dto, ImageUrl, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["Positions"] = _positionService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            var data = _teamBoardService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(TeamBoardUpdateDto dto, IFormFile imageUrl)
        {
            var result = _teamBoardService.Update(dto, imageUrl, _env.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["Positions"] = _positionService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _teamBoardService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
