using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Membership
{
    public class ApplicationUserEditDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public static ApplicationUser ToPosition(ApplicationUserEditDto dto)
        {
            ApplicationUser position = new ApplicationUser()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                ImageUrl = dto.ImageUrl,
                Favourites = dto.Favourites,
                Bookings = dto.Bookings,
            };

            return position;
        }
    }
}
