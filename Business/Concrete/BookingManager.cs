using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
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
        private readonly IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
        public IResult Add(BookingCreateDto dto)
        {
            var model = BookingCreateDto.ToBooking(dto);
            _bookingDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _bookingDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<Booking> GetById(int id)
        {
            return new SuccessDataResult<Booking>(_bookingDal.GetById(id));
        }

        public IDataResult<List<BookingDto>> GetTeamBoardWithPosition()
        {
            return new SuccessDataResult<List<BookingDto>>(_bookingDal.GetBookingWithUserIdAndCarId());
        }

        public IResult Update(BookingUpdateDto dto)
        {
            var model = BookingUpdateDto.ToBooking(dto);
            model.UpdatedDate = DateTime.Now;
            _bookingDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
