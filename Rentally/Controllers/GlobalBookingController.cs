using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class GlobalBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
