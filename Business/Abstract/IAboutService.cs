using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(AboutCreateDto entity);
        IResult Update(AboutUpdateDto entity);
        IDataResult<List<AboutDto>> GetAboutWithCarCustomerBooking();
        IDataResult<About> GetById(int id);
    }
}
