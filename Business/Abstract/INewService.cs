using Core.Results.Abstract;
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
        IResult Add(New entity);
        IResult Update(New entity);
        IResult Delete(int id);
        IDataResult<List<New>> GetAll();
        IDataResult<New> GetById(int id);
    }
}
