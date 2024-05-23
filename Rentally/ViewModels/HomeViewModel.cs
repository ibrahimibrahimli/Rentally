using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Rentally.WEB.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders {  get; set; }
        public List<CarDto> Cars { get; set; }
        public List<AboutDto> Abouts { get; set; }
        public List<Feature> Features { get; set; }
        public List<Testimonial> Testimonials { get; set;}
        public List<New> News { get; set; }
        public List<QA> QAs { get; set; }   
    }
}
