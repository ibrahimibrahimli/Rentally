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
    public class AboutManager : IAboutService
    {
        AboutDal aboutDal = new();
        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);
            aboutDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

 

        public IDataResult<List<AboutDto>> GetAboutWithCarCustomerBooking()
        {
            return new SuccessDataResult<List<AboutDto>>(aboutDal.GetAboutWithCarCustomerBooking());
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(aboutDal.GetById(id));
        }

        public IResult Update(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);
            model.UpdatedDate = DateTime.Now;
            aboutDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
