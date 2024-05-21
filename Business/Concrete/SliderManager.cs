using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        private readonly IValidator<Slider> _validator;

        public SliderManager(ISliderDal sliderDal, IValidator<Slider> validator)
        {
            _sliderDal = sliderDal; 
            _validator = validator;
        }
        public IResult Add(SliderCreateDto dto)
        {
            var model = SliderCreateDto.ToSlider(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _sliderDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(SliderUpdateDto dto)
        {
            var model = SliderUpdateDto.ToSlider( dto );
            model.UpdatedDate = DateTime.Now;
            _sliderDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _sliderDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Slider>> GetAll()
        {
            return new SuccessDataResult<List<Slider>>(_sliderDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Slider> GetById(int id)
        {
            return new SuccessDataResult<Slider>(_sliderDal.GetById(id));
        }

    }
}
