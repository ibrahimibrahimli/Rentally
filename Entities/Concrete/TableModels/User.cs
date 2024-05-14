using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class User : BaseEntity
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public char PhoneNumber { get; set; }
        public string Password { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        //public int FavouriteId { get; set; }
        //public virtual Favourite Favourite { get; set; }

    }

}
