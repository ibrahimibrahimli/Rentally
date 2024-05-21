using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class CarCategoryManager : ICarCategoryService
    {
        private readonly ICarCategoryDal _carCategoryDal;
        private readonly IValidator<CarCategory> _validator;
        public CarCategoryManager(ICarCategoryDal carCategoryDal, IValidator<CarCategory> validator)
        {
            _carCategoryDal = carCategoryDal;   
            _validator = validator;
        }

        public IResult Add(CarCategoryCreateDto dto)
        {
            var model = CarCategoryCreateDto.ToCarCategory(dto);
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

            _carCategoryDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }
        public IResult Update(CarCategoryUpdateDto dto)
        {
            var model = CarCategoryUpdateDto.ToCarCategory(dto);
            model.UpdatedDate = DateTime.Now;
            _carCategoryDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _carCategoryDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<CarCategory>> GetAll()
        {
            return new SuccessDataResult<List<CarCategory>>(_carCategoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<CarCategory> GetById(int id)
        {
            return new SuccessDataResult<CarCategory>(_carCategoryDal.GetById(id));
        }

    }
}
