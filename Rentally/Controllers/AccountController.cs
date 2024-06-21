using Business.Abstract;
using Business.Concrete;
using Core.Extenstion;
using Entities.Concrete.Dtos.Membership;
using Entities.Concrete.TableModels.Membership;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Rentally.WEB.ViewModels;
using System.Security.Claims;

namespace Rentally.WEB.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IBookingService _bookingService;
        private readonly IWebHostEnvironment _env;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IBookingService bookingService, IWebHostEnvironment webHostEnvironment, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _bookingService = bookingService;
            _env = webHostEnvironment;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new();

                user = await _userManager.FindByEmailAsync(dto.Email);

                if(user is null)
                {
                    ViewBag.Message = "E-Poçt və ya şifrə yanlışdır";
                    goto end;
                }
                var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);

                if (result.Succeeded)
                {
                   
                   return RedirectToAction("Index", "Home");
                }
                    ViewBag.Message = "E-Poçt və ya şifrə yanlışdır";
            }
            end:
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
               var roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (!roleResult.Succeeded)
                {
                    ViewBag.Message = "Bir xəta oldu";

                    foreach (var item in roleResult.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                   
                    return View(dto);
                }
                return RedirectToAction("Login");
            }
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            var bookings = _bookingService.GetBookingWithUserIdAndCarId().Data.Where(x => x.UserId == user.Id).ToList();
            ViewData["User"] = user;
            return View(bookings);
        }

        [HttpGet]

        public async Task<IActionResult> EditProfile()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(ApplicationUser user, IFormFile imageUrl, string currentPassword, string newPassword)
        {
            //Write ModelState

            var existUser = await _userManager.FindByEmailAsync(user.Email);

            existUser.UserName = user.UserName;
            existUser.Surname = user.Surname;
            existUser.Name = user.Name;
            existUser.Email = user.Email;

            if(imageUrl != null)
            {
               existUser.ImageUrl = PictureHelper.UploadImage(imageUrl, _env.WebRootPath);
            }
            


            if(currentPassword is not null && newPassword is not null)
            {
                var passwordResult = VerifyHashedPassword(existUser, existUser.PasswordHash, currentPassword);

                if (passwordResult)
                {
                    _userManager.ChangePasswordAsync(existUser, currentPassword, newPassword);

                }
                else
                {
                    ViewBag.Message = "Hazırki şifrə yanlış Daxil edilib";
                }
            }

            
            var result = await _userManager.UpdateAsync(existUser);

            if (!result.Succeeded)
            {
                ViewBag.Message = "Gözlənilməyən xəta baş verdi";

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }

                return View(user);
            }
            return RedirectToAction("Dashboard");
        }

        public bool VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return verificationResult == PasswordVerificationResult.Success;
        }

        public async Task<IActionResult> Orders()
        {
            var user = await _userManager.GetUserAsync(User);
            var bookings = _bookingService.GetBookingWithUserIdAndCarId().Data.Where(x => x.UserId == user.Id).ToList();
            ViewData["User"] = user;
            return View(bookings);
        }
    }
}
