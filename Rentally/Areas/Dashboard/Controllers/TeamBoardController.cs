using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeamBoardController : Controller
    {
        TeamBoardManager _teamBoardManager = new();
        PositionManager _positionManager = new();
        public IActionResult Index()
        {
            var data = _teamBoardManager.GetTeamBoardWithPosition().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Positions"] = _positionManager.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamBoardCreateDto dto)
        {
            var result = _teamBoardManager.Add(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionManager.GetAll().Data;
            var data = _teamBoardManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(TeamBoardUpdateDto dto)
        {
            var result = _teamBoardManager.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var result = _teamBoardManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
