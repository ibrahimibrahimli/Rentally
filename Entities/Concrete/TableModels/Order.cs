using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Order : BaseEntity
    {
        public int BookingId { get; set; }

        //  0-Cancelled, 1-Completed, 2-Scheduled
        public byte Status { get; set; }
        public virtual Booking Booking { get; set; }
    }

}
