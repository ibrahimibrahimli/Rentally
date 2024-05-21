using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        private readonly IValidator<Feature> _validator;
        public FeatureManager(IFeatureDal featureDal, IValidator<Feature> validator)
        {
            _featureDal = featureDal;
            _validator = validator;
        }
        public IResult Add(FeatureCreateDto dto)
        {
            var model = FeatureCreateDto.ToFeature(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _featureDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }
        public IResult Update(FeatureUpdateDto dto)
        {
            var model = FeatureUpdateDto.ToFeature(dto);

            model.UpdatedDate = DateTime.Now;
            _featureDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _featureDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Feature>> GetAll()
        {
            return new SuccessDataResult<List<Feature>>(_featureDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Feature> GetById(int id)
        {
            return new SuccessDataResult<Feature>(_featureDal.GetById(id));
        }


    }
}
