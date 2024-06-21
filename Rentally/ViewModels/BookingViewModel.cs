using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;

namespace Rentally.WEB.ViewModels
{
    public class BookingViewModel
    {
        public List<CarDto> Cars { get; set; }
        public Car SingleCar { get; set; }
        public BookingCreateDto Bookings { get; set; }
        public ApplicationUser User { get; set; }
        public List<Region> Regions { get; set; }
    }
}
