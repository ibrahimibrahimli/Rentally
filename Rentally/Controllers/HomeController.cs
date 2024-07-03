using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.Controllers;
using Rentally.WEB.ViewModels;
using System.Diagnostics;

namespace Rentally.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISliderService _sliderService;
        private readonly ICarService _carService;   
        private readonly IAboutService _aboutService;
        private readonly IFeatureService _featureService;
        private readonly ITestimonialService _testimonialService;
        private readonly INewService _newService;
        private readonly IQAService _qaService;

        public HomeController(ISliderService sliderService, ICarService carService, IAboutService aboutService, IFeatureService featureService, ITestimonialService estimonialService, INewService newService, IQAService qaService)
        {
            _sliderService = sliderService;
            _carService = carService;
            _aboutService = aboutService;
            _featureService = featureService;
            _testimonialService = estimonialService;
            _newService = newService;
            _qaService = qaService;
        }

        public IActionResult Index()
        {
            var sliderData = _sliderService.GetAll().Data;
            var carData = _carService.GetCarWithCategory().Data;
            var aboutData = _aboutService.GetAboutWithCarCustomerBooking().Data;
            var featureData = _featureService.GetAll().Data;
            var testimonialData = _testimonialService.GetAll().Data;
            var newData = _newService.GetAll().Data;
            var qaData = _qaService.GetAll().Data;

            HomeViewModel viewModel = new()
            {
                Sliders = sliderData ?? new List<Slider>(),
                Cars = carData,
                Abouts = aboutData,
                Features = featureData,
                Testimonials = testimonialData,
                News = newData,
                QAs = qaData
            };
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
