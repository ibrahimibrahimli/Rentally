using Core.Results.Abstract;
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
        IResult Add(Booking entity);
        IResult Update(Booking entity);
        IResult Delete(int id);
        IDataResult<List<Booking>> GetTeamBoardWithPosition();
        IDataResult<Booking> GetById(int id);
    }
}
