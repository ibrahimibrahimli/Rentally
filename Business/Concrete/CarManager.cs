using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Core.Extenstion;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IValidator<Car> _validator;
        public CarManager(ICarDal carDal, IValidator<Car> validator)
        {
            _carDal = carDal;
            _validator = validator;
        }

        public IResult Add(Car entity, IFormFile imageUrl, string webRootPath)
        {

            var validator = _validator.Validate(entity);
            entity.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            

            _carDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(Car entity, IFormFile imageUrl, string webRootPath)
        {
            var existData = GetById(entity.Id).Data;
            if (imageUrl == null)
            {
                entity.ImageUrl = existData.ImageUrl;
            }
            else
            {
                entity.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);
            }

            entity.UpdatedDate = DateTime.Now;
            _carDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _carDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(id));
        }

        public IDataResult<List<CarDto>> GetCarWithCategory()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarWithCategory());
        }
    }
}
