﻿using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public int CarID { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public byte Status { get; set; } //  0-Scheduled, 1-Completed, 2-Cancelled
        public string CarBrand { get; set; }
        public string UserName { get; set; }

        public static Booking ToBooking(BookingCreateDto dto)
        {
            Booking booking = new Booking()
            {
                UserId = dto.UserId,
                CarID = dto.CarID,
                PickUpLocation = dto.PickUpLocation,
                DropOffLocation = dto.DropOffLocation,
                PickUpDateTime = dto.PickUpDateTime,
                DropOffDateTime = dto.DropOffDateTime,
                Status = dto.Status,
            };

            return booking;
        }
    }
}