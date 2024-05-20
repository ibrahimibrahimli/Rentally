using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBookingDal : IBaseRepository<Booking>
    {
        List<BookingDto> GetBookingWithUserIdAndCarId();
    }
}
