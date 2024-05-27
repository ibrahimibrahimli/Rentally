using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class GlobalNewController : Controller
    {
        private readonly INewService _newService;
        private readonly ITestimonialService _testimonialService;

        public GlobalNewController(INewService newService, ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
            _newService = newService;
        }
        public IActionResult Index()
        {
            ViewData["Testimonials"] = _testimonialService.GetAll().Data;
            var data = _newService.GetAll().Data;
            return View(data);
        }

      

        public IActionResult Details(int id)
        {
            ViewData["News"] = _newService.GetAll().Data;
            var data = _newService.GetById(id).Data;
            return View(data);
        }

        [HttpGet]

        public IActionResult Error()
        {

            return View();
        }
    }
}
