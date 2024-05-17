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
    public class CarManager : ICarService
    {
        CarDal carDal = new();

        public IResult Add(Car entity)
        {
            carDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(Car entity)
        {
            entity.UpdatedDate = DateTime.Now;
            carDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            carDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(carDal.GetById(id));
        }

        public IDataResult<List<Car>> GetCarWithCategory()
        {
            return new SuccessDataResult<List<Car>>(carDal.GetCarWithCategory());
        }
    }
}
