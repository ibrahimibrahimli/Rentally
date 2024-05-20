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
    public interface IFeatureService
    {
        IResult Add(FeatureCreateDto dto);
        IResult Update(FeatureUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Feature>> GetAll();
        IDataResult<Feature> GetById(int id);
    }
}
