using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class AboutDal : BaseRepository<About, ApplicationDbContext>, IAboutDal
    {
        ApplicationDbContext _context = new(); 
        public List<AboutDto> GetAboutWithCarCustomerBooking()
        {
            int carCount = _context.Cars.Where(x=>x.Deleted==0).Count();
            int customerCount = _context.Users.Where(user => user.Bookings.Count > 0).Count();
            int orderCount = _context.Bookings.Where(booking =>  booking.Status == 1).Count();

            var result = from about in _context.Abouts
                         where about.Deleted == 0
                         select new AboutDto
                         {
                             Id = about.Id,
                             Title = about.Title,
                             Description = about.Description,
                             CompletedOrders = orderCount,
                             Customers = customerCount,
                             Cars = carCount,
                         };

            return result.ToList();
        }
    }
}
