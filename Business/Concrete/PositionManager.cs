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
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;
        private readonly IValidator<Position> _validator;   

        public PositionManager(IPositionDal positionDal, IValidator<Position> validator)
        {
            _positionDal = positionDal;
            _validator = validator;
        }
        public IResult Add(PositionCreateDto dto)
        {
            var model = PositionCreateDto.ToPosition(dto);
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

            _positionDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _positionDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(_positionDal.GetById(id));
        }

        public IResult Update(PositionUpdateDto dto)
        {
            var model = PositionUpdateDto.ToPosition(dto);

            model.UpdatedDate = DateTime.Now;
            _positionDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
