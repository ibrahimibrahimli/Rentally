﻿using Entities.Concrete.Dtos.Membership;
using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginDto dto)
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    EmailConfirmed = false,
                    UserName = dto.UserName,
                    PhoneNumber = dto.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    ViewBag.Message = "Gözlənilməyən xəta baş verdi";

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }

                    return View(dto);
                }

                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
