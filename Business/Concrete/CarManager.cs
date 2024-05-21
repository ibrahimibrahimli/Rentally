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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IResult Add(Car entity)
        {

            var validator = _validator.Validate(entity);

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

        public IResult Update(Car entity)
        {
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
