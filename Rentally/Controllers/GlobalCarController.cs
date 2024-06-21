using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rentally.WEB.Controllers
{
    public class GlobalCarController : BaseController
    {
        private readonly ICarService _carService;
        public GlobalCarController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            var carData = _carService.GetCarWithCategory().Data;
            return View(carData);
        }
    }
}
