using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
