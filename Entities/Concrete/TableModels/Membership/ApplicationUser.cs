
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.TableModels.Membership
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public virtual string PhoneNumber { get; set; }
        public ApplicationUser()
        {
            Bookings = new HashSet<Booking>();
        }

        public ICollection<Booking> Bookings { get; set; }
    }
}
