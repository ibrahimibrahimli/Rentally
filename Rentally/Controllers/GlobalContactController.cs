using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    
    public class GlobalContactController : Controller
    {
        private readonly IContactService _contactService;

        public GlobalContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }
    }
}
