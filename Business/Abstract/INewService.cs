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
    public interface INewService
    {
        IResult Add(NewCreateDto dto);
        IResult Update(NewUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<New>> GetAll();
        IDataResult<New> GetById(int id);
    }
}
