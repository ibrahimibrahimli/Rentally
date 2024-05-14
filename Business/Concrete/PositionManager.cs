using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        PositionDal positionDal = new();
        public IResult Add(Position entity)
        {
            positionDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            positionDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(positionDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(positionDal.GetById(id));
        }

        public IResult Update(Position entity)
        {
            entity.UpdatedDate = DateTime.Now;
            positionDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
