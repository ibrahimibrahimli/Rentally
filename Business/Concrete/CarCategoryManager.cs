using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class CarCategoryManager : ICarCategoryService
    {
        CarCategoryDal carCategoryDal = new();
        public IResult Add(CarCategory entity)
        {
            carCategoryDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }
        public IResult Update(CarCategory entity)
        {
            entity.UpdatedDate = DateTime.Now;
            carCategoryDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            carCategoryDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<CarCategory>> GetAll()
        {
            return new SuccessDataResult<List<CarCategory>>(carCategoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<CarCategory> GetById(int id)
        {
            return new SuccessDataResult<CarCategory>(carCategoryDal.GetById(id));
        }

    }
}
