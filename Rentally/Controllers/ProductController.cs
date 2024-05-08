using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.Models;

namespace Rentally.WEB.Controllers
{
    public class ProductController : Controller
    {
        List<Car> cars = new()
        {
            new Car { Id = 1, Name= "Hyundai"},
            new Car { Id = 2, Name= "Mercedes"},
            new Car { Id = 3, Name= "Toyota"},
            new Car { Id = 4, Name= "Bmw"}
        };
        public IActionResult Index()
        {
            return View(cars);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
