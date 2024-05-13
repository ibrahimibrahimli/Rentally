using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarCategoryService
    {
        IResult Add(CarCategory entity);
        IResult Update(CarCategory entity);
        IResult Delete(int id);
        IDataResult<List<CarCategory>> GetAll();
        IDataResult<CarCategory> GetById(int id);
    }
}
