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
    public interface IRegionService
    {
        IResult Add(RegionCreateDto dto);
        IResult Update(RegionUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Region>> GetAll();
        IDataResult<Region> GetById(int id);
    }
}
