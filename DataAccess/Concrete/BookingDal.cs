using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class BookingDal : BaseRepository<Booking, ApplicationDbContext>, IBookingDal
    {
        ApplicationDbContext context = new();
        public List<Booking> GetBookingWithUserIdAndCarId()
        {
            var data = context.Bookings
                .Where(x => x.Deleted == 0)
                .Include(x => x.User)
                .Include(x => x.Car)
                .ToList();
            return data;
        }
    }
}
