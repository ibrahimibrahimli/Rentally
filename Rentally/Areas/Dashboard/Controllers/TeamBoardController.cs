﻿using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeamBoardController : Controller
    {
        TeamBoardManager _teamBoardManager = new();
        public IActionResult Index()
        {
            var data = _teamBoardManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamBoard teamBoard)
        {
            var result = _teamBoardManager.Add(teamBoard);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(teamBoard);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _teamBoardManager.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(TeamBoard teamBoard)
        {
            var result = _teamBoardManager.Update(teamBoard);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(teamBoard);
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
