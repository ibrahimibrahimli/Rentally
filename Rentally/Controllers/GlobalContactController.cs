using Business.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    
    public class GlobalContactController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContactService _contactService;

        public GlobalContactController(UserManager<ApplicationUser> userManager, IContactService contactService)
        {
            _userManager = userManager;
            _contactService = contactService;
        }
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewData["User"] = user;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ContactCreateDto dto)
        {

            var result = _contactService.Add(dto);

            if (!result.IsSuccess)
            {
                return Json(new { isSuccess = false });

            }
            return Json(new { isSuccess = true });
            
        }
        
    }
}
