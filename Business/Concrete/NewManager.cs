using Business.Abstract;
using Business.BaseMessages;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
namespace Business.Concrete
{
    public class NewManager : INewService
    {
        private readonly INewDal _newDal;
        private readonly IValidator<New> _validator;

        public NewManager(INewDal newDal, IValidator<New> validator)
        {
            _newDal = newDal;
            _validator = validator;
        }
        public IResult Add(NewCreateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model  = NewCreateDto.ToNew(dto);
            var validator = _validator.Validate(model);
            model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _newDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _newDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<New>> GetAll()
        {
            return new SuccessDataResult<List<New>>(_newDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<New> GetById(int id)
        {
            return new SuccessDataResult<New>(_newDal.GetById(id)); 
        }

        public IResult Update(NewUpdateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = NewUpdateDto.ToNew(dto);

            var existData = GetById(dto.Id).Data;
            if (imageUrl == null)
            {
                model.ImageUrl = existData.ImageUrl;
            }
            else
            {
                model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);
            }

            
            model.UpdatedDate = DateTime.Now;
            _newDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
