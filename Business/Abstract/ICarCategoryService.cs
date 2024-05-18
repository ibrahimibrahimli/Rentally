using Core.Results.Abstract;
using Entities.Concrete.Dtos;
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
        IResult Add(CarCategoryCreateDto dto);
        IResult Update(CarCategoryUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<CarCategory>> GetAll();
        IDataResult<CarCategory> GetById(int id);
    }
}
