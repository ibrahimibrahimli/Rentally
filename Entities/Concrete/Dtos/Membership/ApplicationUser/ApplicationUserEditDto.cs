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
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int FavouriteId { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public static ApplicationUser ToUser(ApplicationUserEditDto dto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                ImageUrl = dto.ImageUrl,
                PasswordHash = dto.Password,
                UserName = dto.UserName,
                Email = dto.Email,
                Bookings = dto.Bookings,
            };

            return user;
        }
    }
}
