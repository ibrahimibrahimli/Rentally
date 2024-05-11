using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    //------------------------
    public class Booking : BaseEntity
    {
        public int UserId { get; set; }
        public int CarID { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }

}
