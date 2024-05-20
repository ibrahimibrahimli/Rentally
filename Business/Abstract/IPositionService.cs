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
    public interface IPositionService
    {
        IResult Add(PositionCreateDto dto);
        IResult Update(PositionUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Position>> GetAll();
        IDataResult<Position> GetById(int id);
    }
}
