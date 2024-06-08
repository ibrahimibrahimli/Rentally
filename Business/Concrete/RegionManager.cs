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
    public class RegionManager : IRegionService
    {
        private readonly IRegionDal _regionDal;
        private readonly IValidator<Region> _validator;

        public RegionManager(IRegionDal regionDal, IValidator<Region> validator)
        {
            _regionDal = regionDal;
            _validator = validator;
        }

        public IResult Add(RegionCreateDto dto)
        {
            var model = RegionCreateDto.ToRegion(dto);
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

            _regionDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(RegionUpdateDto dto)
        {
            var model = RegionUpdateDto.ToRegion(dto);
            model.UpdatedDate = DateTime.Now;
            _regionDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _regionDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Region>> GetAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Region> GetById(int id)
        {
            return new SuccessDataResult<Region>(_regionDal.GetById(id));
        }
    }
}
