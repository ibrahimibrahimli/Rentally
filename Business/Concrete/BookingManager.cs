using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookingManager : IBookingService
    {
        BookingDal bookingDal = new();
        public IResult Add(Booking entity)
        {
            bookingDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            bookingDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<Booking> GetById(int id)
        {
            return new SuccessDataResult<Booking>(bookingDal.GetById(id));
        }

        public IDataResult<List<Booking>> GetTeamBoardWithPosition()
        {
            return new SuccessDataResult<List<Booking>>(bookingDal.GetBookingWithUserIdAndCarId());
        }

        public IResult Update(Booking entity)
        {
            entity.UpdatedDate = DateTime.Now;
            bookingDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
