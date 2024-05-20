using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class BookingDal : BaseRepository<Booking, ApplicationDbContext>, IBookingDal
    {
        ApplicationDbContext _context = new();
        public List<BookingDto> GetBookingWithUserIdAndCarId()
        {

            var result = from booking in _context.Bookings
                         where booking.Deleted == 0
                         join user in _context.Users on booking.UserId equals user.Id
                         where user.Deleted == 0
                         join car in _context.Cars on booking.CarID equals car.Id
                         where car.Deleted == 0
                         select new BookingDto
                         {
                             Id = booking.Id,
                             UserId = user.Id,
                             CarID = car.Id,
                             PickUpDateTime = booking.PickUpDateTime,
                             PickUpLocation = booking.PickUpLocation,
                             DropOffDateTime = booking.DropOffDateTime,
                             DropOffLocation = booking.DropOffLocation,
                             Status = booking.Status,
                             CarBrand = car.Brand,
                             UserName = user.Name,
                         };


            return result.ToList();
        }
    }
}
