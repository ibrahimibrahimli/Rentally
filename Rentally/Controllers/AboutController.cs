using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
