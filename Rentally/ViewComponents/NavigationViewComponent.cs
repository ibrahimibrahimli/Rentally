using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.Models;

namespace Rentally.WEB.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public NavigationViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _ = new ApplicationUser();
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
                return View(new NavigationViewModel()
                {
                    User = user
                });
            }
            return View(new NavigationViewModel() { User = null});

        }
    }
}
