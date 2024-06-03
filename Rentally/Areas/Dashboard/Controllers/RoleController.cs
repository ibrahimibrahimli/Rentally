using Business.Abstract;
using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ApplicationRole role)
        {


            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(role);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            return RedirectToAction("Index");
        }
    }
}
