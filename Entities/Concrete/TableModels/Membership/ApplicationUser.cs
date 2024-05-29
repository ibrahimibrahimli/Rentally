
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.TableModels.Membership
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Bookings = new HashSet<Booking>();
            Favourites = new HashSet<Favourite>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
