using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(int id);
        IDataResult<List<Car>> GetCarWithCategory();
        IDataResult<Car> GetById(int id);
    }
}
