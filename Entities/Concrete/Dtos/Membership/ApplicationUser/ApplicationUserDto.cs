using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Membership
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public  List<string> Roles { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public static ApplicationUser ToPosition(ApplicationUserDto dto)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                ImageUrl = dto.ImageUrl,
                Favourites = dto.Favourites,
                Bookings = dto.Bookings,
            };

            return applicationUser;
        }
    }
}
