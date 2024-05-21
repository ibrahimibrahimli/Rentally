using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeamBoardController : Controller
    {
        private readonly ITeamBoardService _teamBoardService;
        private readonly IPositionService _positionService;

        public TeamBoardController(ITeamBoardService teamBoardService, IPositionService positionService)
        {
            _teamBoardService = teamBoardService;
            _positionService = positionService;
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
        public IActionResult Create(TeamBoardCreateDto dto)
        {
            var result = _teamBoardService.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            var data = _teamBoardService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(TeamBoardUpdateDto dto)
        {
            var result = _teamBoardService.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
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
