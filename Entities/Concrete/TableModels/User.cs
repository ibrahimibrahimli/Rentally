using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //------------
    public class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Favourites = new HashSet<Favourite>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte PhoneNUmber { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }

}
