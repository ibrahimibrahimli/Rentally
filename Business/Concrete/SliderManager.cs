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
    public class SliderManager : ISliderService
    {
        SliderDal sliderDal = new();
        public IResult Add(Slider entity)
        {
            sliderDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(Slider entity)
        {
            entity.UpdatedDate = DateTime.Now;
            sliderDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            sliderDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Slider>> GetAll()
        {
            return new SuccessDataResult<List<Slider>>(sliderDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Slider> GetById(int id)
        {
            return new SuccessDataResult<Slider>(sliderDal.GetById(id));
        }

    }
}
