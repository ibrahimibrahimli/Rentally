using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Areas.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        [Area("Dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
