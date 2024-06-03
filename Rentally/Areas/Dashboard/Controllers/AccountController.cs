using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            ViewData["Roles"] = _roleManager.Roles;
            var data = _userManager.Users.ToList();
            return View(data);
        }

        //[HttpGet]

        //public IActionResult AddAdminRoleToUser(string email, int id)
        //{
        //    ViewData["Roles"] = _roleManager.Roles;
        //    var data = _userManager.FindByEmailAsync(email);

        //    return View(data);
        //}

        [HttpPost]
        public async Task<IActionResult> AddAdminRoleToUser(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Kullanıcı bulunamadı: {userId}");
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Index");
        }


    }
}
