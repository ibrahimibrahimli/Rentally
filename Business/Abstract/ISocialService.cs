using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISocialService
    {
        IResult Add(Social entity);
        IResult Update(Social entity);
        IResult Delete(int id);
        IDataResult<List<Social>> GetAll();
        IDataResult<Social> GetById(int id);
    }
}
