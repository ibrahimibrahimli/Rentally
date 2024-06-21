using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Car : BaseEntity
    {
        public Car()
        {
            FavouriteItems = new HashSet<FavouriteItem>();
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CarCategoryId { get; set; }
        public int DoorCount { get; set; }
        public int Count { get; set; }
        public int PassengerCount { get; set; }
        public DateTime Year { get; set; } 
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHomePage { get; set; }
        public ICollection<FavouriteItem> FavouriteItems { get; set; }
        public virtual CarCategory CarCategory { get; set; }
    }

}
