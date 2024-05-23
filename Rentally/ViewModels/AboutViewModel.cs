using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Rentally.WEB.ViewModels
{
    public class AboutViewModel
    {
        public List<AboutDto> Abouts { get; set; }
        public List<Feature> Features { get; set; }
        public List<TeamBoardDto> TeamBoards { get; set; }
    }
}
