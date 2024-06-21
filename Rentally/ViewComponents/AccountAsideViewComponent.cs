using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.Models;

namespace Rentally.WEB.ViewComponents
{
    public class AccountAsideViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountAsideViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            return View(new AccountAsideViewModel()
            {
                User = user
            });
        }
    }
}
