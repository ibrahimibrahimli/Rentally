using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About entity);
        IResult Update(About entity);
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetById(int id);
    }
}
