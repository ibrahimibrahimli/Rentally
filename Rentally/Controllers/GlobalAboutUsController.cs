using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Rentally.WEB.ViewModels;

namespace Rentally.WEB.Controllers
{
    public class GlobalAboutUsController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ITeamBoardService _teamBoardService;
        private readonly IFeatureService _featureService;

        public GlobalAboutUsController(IAboutService aboutService, ITeamBoardService teamBoardService, IFeatureService featureService)
        {
            _aboutService = aboutService;
            _teamBoardService = teamBoardService;
            _featureService = featureService;
        }
        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAboutWithCarCustomerBooking().Data;
            var teamboardData = _teamBoardService.GetTeamBoardWithPosition().Data;
            var featureData = _featureService.GetAll().Data;

            AboutViewModel viewModel = new()
            {
                Abouts = aboutData,
                TeamBoards = teamboardData,
                Features = featureData
            };

            return View(viewModel);
        }
    }
}
