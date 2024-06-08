using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BookingUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarID { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string Message { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public byte Status { get; set; } //  0-Scheduled, 1-Completed, 2-Cancelled
        public string CarBrand { get; set; }
        public string UserName { get; set; }

        public static Booking ToBooking(BookingUpdateDto dto)
        {
            Booking booking = new Booking()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                CarID = dto.CarID,
                PickUpLocation = dto.PickUpLocation,
                DropOffLocation = dto.DropOffLocation,
                PickUpDateTime = dto.PickUpDateTime,
                DropOffDateTime = dto.DropOffDateTime,
                Message = dto.Message,
                Status = dto.Status,
            };

            return booking;
        }
    }
}
