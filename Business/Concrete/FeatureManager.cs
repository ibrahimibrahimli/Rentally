using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeatureManager : IFeatureService
    {
        FeatureDal featureDal = new();
        public IResult Add(FeatureCreateDto dto)
        {
            var model = FeatureCreateDto.ToFeature(dto);

            featureDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }
        public IResult Update(FeatureUpdateDto dto)
        {
            var model = FeatureUpdateDto.ToFeature(dto);

            model.UpdatedDate = DateTime.Now;
            featureDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            featureDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Feature>> GetAll()
        {
            return new SuccessDataResult<List<Feature>>(featureDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Feature> GetById(int id)
        {
            return new SuccessDataResult<Feature>(featureDal.GetById(id));
        }


    }
}
