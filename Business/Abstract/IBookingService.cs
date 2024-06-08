using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookingService
    {
        IResult Add(BookingCreateDto entity);
        IResult Update(BookingUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<BookingDto>> GetBookingWithUserIdAndCarId();
        IDataResult<Booking> GetById(int id);
    }
}
