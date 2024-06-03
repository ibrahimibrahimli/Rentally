﻿using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {

            var data = _aboutService.GetAboutWithCarCustomerBooking().Data;
            ViewBag.ShowButton = data.Count() == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutCreateDto dto)
        {
            var result = _aboutService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _aboutService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]

        public IActionResult Edit(AboutUpdateDto dto)
        {
            var result = _aboutService.Update(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
