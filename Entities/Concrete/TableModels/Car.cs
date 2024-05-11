using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //----------------------
    public class Car : BaseEntity
    {
        public Car()
        {
            Favourites = new HashSet<Favourite>();
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarCategoryId { get; set; }
        public int DoorCount { get; set; }
        public decimal PricePerDay { get; set; }
        public int FavouriteCount { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public virtual CarCategory CarCategory { get; set; }
    }

}
