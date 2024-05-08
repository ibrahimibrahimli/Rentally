using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
