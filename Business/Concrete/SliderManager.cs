using Business.Abstract;
using Business.BaseMessages;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

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
        public IResult Add(SliderCreateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = SliderCreateDto.ToSlider(dto);
            var validator = _validator.Validate(model);
            model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);

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

        public IResult Update(SliderUpdateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = SliderUpdateDto.ToSlider( dto );

            var existData = GetById(dto.Id).Data;
            if (imageUrl == null)
            {
                model.ImageUrl = existData.ImageUrl;
            }
            else
            {
                model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);
            }

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
